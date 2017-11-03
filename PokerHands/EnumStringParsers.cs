using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public enum CardSuit { Joker, Club, Diamond, Heart, Spade };
    public enum CardValue { Joker, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };

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

        public static CardSuit StringToCardSuit(string suit)
        {
            switch(suit)
            {
                case "S":
                    return CardSuit.Spade;
                case "H":
                    return CardSuit.Heart;
                case "C":
                    return CardSuit.Club;
                case "D":
                    return CardSuit.Diamond;
                default:
                    return CardSuit.Joker;
            }
        }

        /// <summary>
        /// Converts a string shorthand value of a card
        /// to the corresponding CardValue enum
        /// </summary>
        /// <param name="value">string shorthand value of card</param>
        /// <returns>CardValue enum representation</returns>
        public static CardValue StringToCardValue(string value)
        {
            switch (value)
            {
                case "2":
                    return CardValue.Two;
                case "3":
                    return CardValue.Three;
                case "4":
                    return CardValue.Four;
                case "5":
                    return CardValue.Five;
                case "6":
                    return CardValue.Six;
                case "7":
                    return CardValue.Seven;
                case "8":
                    return CardValue.Eight;
                case "9":
                    return CardValue.Nine;
                case "10":
                    return CardValue.Ten;
                case "J":
                    return CardValue.Jack;
                case "Q":
                    return CardValue.Queen;
                case "K":
                    return CardValue.King;
                case "A":
                    return CardValue.Ace;
                default:
                    return CardValue.Joker;
            }
        }
    }
}
