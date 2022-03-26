using Few.Giveaway.Domain;
using FEW.Db.CQS;
using FEW.Db.DbConnection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FEW.GiveawayBot.App.Services
{
    public class GiveawayComputeService
    {
        private readonly ILogger _logger;
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public GiveawayComputeService(IDbConnectionFactory dbConnectionFactory, ILogger logger)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _logger = logger;
        }

        public async Task<List<ulong>> RollWinners(
            List<RollComputeUserData> userDatas, 
            ulong roleId,
            int targetWinnerCount)
        {
            if (userDatas.Count <= targetWinnerCount)
                return userDatas.Select(u => u.UserId).ToList();

            var origPenalties = await GetPenalties(
                userDatas,
                roleId
            );

            var origPenaltyUserIds = origPenalties.Select(p => p.UserId).ToList();

            var computePenalties = new List<GiveawayPenaltySignup>();

            // Users with more than 1 entry are added to the pool here
            foreach (var userData in userDatas)
            {
                if (origPenaltyUserIds.Contains(userData.UserId))
                {
                    var origPenalty = origPenalties.First(p => p.UserId == userData.UserId);
                    for (int i = 0; i < userData.Entries; i++)
                        computePenalties.Add(new GiveawayPenaltySignup()
                        {
                            UserId = userData.UserId,
                            PenaltyScore = origPenalty.PenaltyScore
                        });
                }
                else
                {                    
                    for (int i = 0; i < userData.Entries; i++)
                        computePenalties.Add(new GiveawayPenaltySignup() { 
                            UserId = userData.UserId, 
                            PenaltyScore = 0 
                        });
                }
            }

            Random rand = new Random();
            var winners = new List<ulong>();
            while (winners.Count < targetWinnerCount)
            {
                // Get a random user
                var next = rand.Next(0, computePenalties.Count);
                var currPs = computePenalties[next];

                if (currPs.PenaltyScore > 0)
                {
                    // This user has penalties so decrement the penalty of their entry
                    currPs.PenaltyScore -= 1;

                    // We landed on a penalty so reroll
                    continue;
                }

                // We landed on a user that's already won so reroll
                if (winners.Contains(currPs.UserId))
                    continue;

                // User had no penalties left so they win
                winners.Add(currPs.UserId);
            }

            return winners;
        }

        public async Task<List<GiveawayPenaltySignup>> GetPenalties(
            List<RollComputeUserData> userDatas, 
            ulong roleId)
        {            
            // We use different "buckets" of giveaways. For example, VIP giveaways should not be affected by
            // public giveaways and vice versa when calculating penalties = the VIP giveaway users should not be punished
            // for signing up for public giveaways
            // So for calculating penalties we only consider past giveaways that belonged to the role for this giveaway                
            List<PastGiveawayWinner> pastWinners;
            using (var con = _dbConnectionFactory.GetNewConnection()) { 
                pastWinners = await new GetPastGiveawayWinnersPerRole(con).Execute(roleId);
            }

            var res = new List<GiveawayPenaltySignup>();
            if (!pastWinners.Any())
            {
                // No wins recorded for this role so return a default state
                foreach (var userData in userDatas)
                    res.Add(new GiveawayPenaltySignup() { UserId = userData.UserId, PenaltyScore = 0 });

                return res;
            }

            // Users are assigned a penalty count if they have recently won 
            // which will later be used to force a reroll if a roll lands on this user
            // If a user has multiple tokens they get a better chance in the distribution 
            // since they are added multiple times

            // We use roleMemberCount to check the max size of the giveaway and to calculate a linear decay period
            // This is to gauge the interest of the giveaway. If almost all members of a role are participating
            // then this giveaway is highly coveted and should have a larger impact on the penalty
            // likewise if nobody cares about it, because it's a trash giveaway, then only a minor penalty should be given
            int giveawayParticipants = userDatas.Count();
            foreach (var userData in userDatas)
            {
                double totalPenalty = 0;

                var pastTime = DateTime.UtcNow.AddMonths(-1);
                var pastWins = pastWinners
                    .Where(p => p.UserId == userData.UserId)
                    .Where(p => p.EndDate >= pastTime)
                    .ToList();

                foreach (var win in pastWins)
                {
                    var tickDelta = (double)(DateTime.UtcNow - pastTime).Ticks;
                    var pastTickDelta = (double)(DateTime.UtcNow - win.EndDate).Ticks;

                    // linear decay over time
                    // A recent win will be treated with higher penalty
                    // If high (~1) then the user recently won
                    // If low (~0) the user won a long time ago
                    double tickRatio = 1 - (pastTickDelta / tickDelta);

                    var signups = (double) win.Signups;
                    var maxParticipants = (double) win.MaxParticipants;

                    // Calculate the participation ratio of this giveaway
                    // If high (~0.5) then the giveaway was highly coveted
                    // If low (~0) then nobody cared and the user should not be punished for winning trash
                    double participationRatio = (signups / maxParticipants) / 2;

                    // We apply the total penalties according to the above reasoning
                    totalPenalty += tickRatio;
                    totalPenalty += participationRatio;
                }

                // Do not make it impossible for a historically lucky user to win
                // This is difficult enough
                if (totalPenalty > 3)
                    totalPenalty = 3;

                res.Add(new GiveawayPenaltySignup()
                {
                    PenaltyScore = totalPenalty,
                    UserId = userData.UserId
                });
            }

            return res;
        }
    }
}
