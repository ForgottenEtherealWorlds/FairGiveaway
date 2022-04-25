# Introducing the FEW FairGiveaway bot
![enter image description here](https://i.imgur.com/GomkIzR.jpeg)

## The issue of unlucky giveaways

All servers using a standard giveaway bot will face the issue of some users winning many times while other users are left empty-handed. **This is due to that giveaway bots are using a completely random, very simple dice rolled system, where no consideration is taken into previous wins when establishing a winner.**

[Forgotten Ethereal Worlds (**FEW**)](https://twitter.com/Forgot3thWorlds) wants to alleviate this issue by introducing our exclusive **FairGiveaway** bot that will make **unlucky participants win more and lucky participants win less, creating a fair environment.**

Over a short amount of time this will result in that **everyone will win with equal chance.**

![enter image description here](https://i.imgur.com/ESMEua2.png)

The bot analyses statistics in terms of amount of wins, how recently a win was made and also how desired the giveaway was. Additionally, the bot only considers giveaways belonging to a certain role when making decisions for that role in the future. 

For example: FEW has exclusive and high-value giveaways for our token holders, their role called *Ascended*. There are also public giveaways where everyone can participate. **With the FairGiveaway system an *Ascended* user winning a public giveaway will never be negatively affected when later rolling on an *Ascended*-only giveaway, and vice versa.**

Considering that the most highly valued giveaways are for our token holders, their chances to win an exclusive giveaway will remain unchanged, regardless of their participation in the public givaways.

## Features

- Custom algorithm that determines the winner in a fair manner
- Anti-cheat features (can be privately disclosed upon request)
- Whisper winner list upon giveaway expiry
- Add winners to a specific channel
- Gather addresses from a specific channel
- Export winners and addresses to a spreadsheet format
- Create, prematurely end, cancel and list all giveaways
- Role filtering - only a certain role can sign up for a giveaway
- Multiple token bonus - give your biggest holders multiple entries

## For multiple token holders

Those holding multiple [FEW Genesis tokens](https://opensea.io/collection/forgotten-ethereal-worlds), and also our [1/1 tokens (Few Genesis Prime)](https://opensea.io/collection/forgotten-ethereal-worlds-specials), **will have multiple entries into all giveaways, effectively boosting their chances to win.** 🐋

In short, every token held will be treated like another signup on a giveaway when establishing a winner. 

**NOTE FOR HOLDERS** Please re-register on Collab.Land on the FEW Discord server for the FairGiveaway bot to be able to read the amount of tokens you hold.

# Use cases

Let us consider the five following users signing up for a giveaway.

- **StandardLuck** has won 3 times in total, but only 1 recently.
- **VeryLucky** has won 3 times recently.
- **Unlucky** has won 1 time a long time ago.
- **MegaLuck** has won 10 times recently.
- **RecentLuck** has won 1 time recently.

## Case 1 - A normal bot

Consider a regular giveaway bot, using a simple dice system. In this system every user has the same chance to win, regardless of past wins. It is purely luck.

Example: 20 winners are drawn out of 345 total, with every giveaway being repeated 100 times.

| Name | Winchance (%)|
|--|--|
| StandardLuck  | 5 |
| VeryLucky | 8 |
| Unlucky | 3 |
| MegaLuck | 12 |
| RecentLuck | 6 |

Even over 100 giveaways, using a standard giveaway bot, the Unlucky can still remain unlucky, while MegaLuck still continues to win a lot. The giveaways will continue to spin randomly, uncaring for Unlucky's fate.

According to the math of a random giveaway: if we had an infinite amount of giveaways then everyone would have an equal chance. **But we do not have infinite time and giveaways, and so FairGiveaway bot will force equality very quickly.**

## Case 2-4 - FairGiveaway bot

We will now use the FairGiveaway bot, which takes into consideration the past statistics of giveaway winners (Scroll up for details on the participant past performance).

This data is based on the current *Ascended* statistics gathered from past (normal) giveaways.

For all these following cases: 20 winners drawn out of 345, with this giveaway completed 100 times.

### Case 2 - FairGiveaway bot

| Name | Winchance (%) |
|--|--|
| StandardLuck  | 5 |
| VeryLucky | 3 |
| Unlucky | 41 |
| MegaLuck | 1 |
| RecentLuck | 4 |

This time Unlucky has a much higher chance of winning, while MegaLuck's lucky streak will most likely be broken. People that has recently won will have a lower chance to win as well, but not as much reduced as MegaLuck.

**Note that the bot does not guarantee an unlucky winner to win**, it simply greatly boosts their chances of doing so.

**Note that, in practice, winning will drastically change your chances to win the next time**. This is not reflected in the above result, as it's just a simple way to show the winning chances in a vacuum. 


### Case 3 - FairGiveaway bot + Multiple entries

Multiple token holders will have multiple entries in a giveaway. Let us take an example with FairGiveaway where **StandardLuck has 3 FEW tokens (entries)  while the rest have 1 entries.**

| Name | Winchance (%) |
|--|--|
| StandardLuck  | 10|
| VeryLucky | 3 |
| Unlucky | 38|
| MegaLuck | 2 |
| RecentLuck | 3 |

StandardLuck, with 3 entries, greatly boosted their chances to win from 5% to 10%. Unlucky still won as much as previously, despite StandardLuck having an advantage. VeryLucky and MegaLuck struggles even more with StandardLuck being around.

### Case 4 - FairGiveaway bot + Multiple entries v.2

Now, consider if MegaLuck has 3 entries. 

| Name | Winchance (%) |
|--|--|
| StandardLuck  | 6|
| VeryLucky | 3 |
| Unlucky | 40|
| MegaLuck | 8 |
| RecentLuck | 4 |

Comparing to case 3, MegaLuck still has a fair chance to win despite winning so much, because they hold multiple FEW tokens (entries). This boosted their chances to win from 2% to 8%. Unlucky is heavily biased to win despite this while the rest have subdued chances, but still within reason as influenced by their past statistics.

## Final words
To repeat, **these results are only representative for the immediate future.**
**The purpose of the bot is to have everyone win equally**, so these percentages will become the same for everyone except those who hold multiple tokens.

**If you do not participate in a giveaway it is the same as you losing it**, as far as the algorithm is concerned. Consequently you will have a higher chance to win the next giveaway, regardless of you clicking the current or not.

**If a participant wins multiple times in a row they will have a lower chance to win again for about 1-2 months**, but it is certainly not impossible to win again. If a participant only wins once occasionally it will not have much impact and they will have a good chance to win again.

Multiple holders will effectively be treated as another person per token, making their chances add up. 3 tokens x 5% chance to win for each token = 15% chance to win.

So we will, when the bot has gathered statistics of many giveaways, end up with this chance for 20 winners drawn out of 345.

| Name | Winchance (%) |
|--|--|
| Multiple holder (3 tokens)| 15|
| Regular holder (1 tokens) | 5 |
| Regular holder (1 tokens) | 5|
| Regular holder (1 tokens) | 5 |
| Regular holder (1 tokens)| 5 |

## Gaming the system

The astute among you will likely have thought to purposefully not participate in giveaways in order to accumulate "losses" which will make your next winchance higher for a more desirable, future giveaway.

Keep in mind that there's a roof on the penalties that a participant can accumulate. If you win 3-4 times in a short time period (1-2 months) it will be treated the same as winning 10 (as some users have). Your penalty also decays quickly over time, making it seem as if you won nothing and you'll be back at the default chance to win. And fact is that if you do not participate in a giveaway you forfeit your chance to win it. So it is worth the opportunity cost to not participate in order to slightly boost your chance to win a future and uncertain giveaway?

My goal with this bot is to make this strategy less valid, and for everyone to simply sign up on the giveaways they want and not think too hard about this system. 

So ultimately: you will have a good chance win again even if you have won recently. 
  
## Technical explanation

The purpose of the winner selection algorithm is to create a self-adjusting environment resulting in a fast-forming continuous uniform distribution for giveaway wins. To accomplish this each win compounds into penalties - adjusted for time recency, desirability of the win and aggregated into role buckets, creating an negatively biased psuedo-random chance for lucky participants.

One would think that an entirely random environment would be uniform and without bias, and while this is true in theory, it is not the case in practice since we do not have infinite time to flatten out the distribution.

Consequently a heavier hand must be put down to speed up this process.

Refer to the Code section for details about the algorithm, as the code is documented heavily.

## Code

As of now we have decided to not publish the entirety of the FairGiveaway bot, but only the critical part that handles the evaluation of winners. The reason for this is to protect the exclusivity of it for the [Forgotten Ethereal Worlds (**FEW**)](https://twitter.com/Forgot3thWorlds) server.

https://github.com/ForgottenEtherealWorlds/FairGiveaway/blob/main/GiveawayComputeService.cs

Thanks for reading! / Caliban



