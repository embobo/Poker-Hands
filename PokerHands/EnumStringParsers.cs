using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public static class EnumStringParsers
    {
        public static string HandRankToString(HandRank hand)
        {
            switch (hand)
            {
                case HandRank.High_Card:
                    return "High Card";
                case HandRank.Pair:
                    return "Pair";
                case HandRank.Two_Pair:
                    return "Two Pair";
                case HandRank.Three_of_a_Kind:
                    return "Three of a Kind";
                case HandRank.Straight:
                    return "Straight";
                case HandRank.Flush:
                    return "Flush";
                case HandRank.Full_House:
                    return "Full House";
                case HandRank.Four_of_a_Kind:
                    return "Four of a Kind";
                case HandRank.Straight_Flush:
                    return "Straight Flush";
                case HandRank.Royal_Flush:
                    return "Royal Flush";
                default:
                    return "Invalid";
            }
        }
    }
}
