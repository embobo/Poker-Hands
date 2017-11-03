using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public enum HandRank
    {
        DEFAULT,
        High_Card,
        Pair,
        Two_Pair,
        Three_of_a_Kind,
        Straight,
        Flush,
        Full_House,
        Four_of_a_Kind,
        Straight_Flush,
        Royal_Flush
    }
    
    /// <summary>
    /// Takes a CardHand and determines its best hand
    /// </summary>
    public class HandEvaluationObject : IEquatable<HandEvaluationObject>, 
                                        IComparable<HandEvaluationObject>
    {
        private HandEvaluationObject() { }

        /// <summary>
        /// Creates a HandEvaluationObject given a player
        /// </summary>
        /// <param name="player"></param>
        public HandEvaluationObject(CardHand player)
        {
            // set values
            this.id = player.ID;
            this.rank = HandRank.DEFAULT;
            this.unranked_card_values = new List<CardValue>();
            this.cards = player.Cards.OrderByDescending(card => card.Value).ToList();
            EvaluateStrength();
        }

        public static bool operator ==(HandEvaluationObject h1, 
            HandEvaluationObject h2)
        {
            if (ReferenceEquals(h1, h2)) return true;
            if (ReferenceEquals(h1, null)) return false;
            if (ReferenceEquals(h2, null)) return false;
            return !(h1.IsStrongerThan(h2) || h2.IsStrongerThan(h1));
        }
        public static bool operator !=(HandEvaluationObject h1,
            HandEvaluationObject h2)
        {
            return !(h1 == h2);
        }

        public bool Equals(HandEvaluationObject other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this == other;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.GetType() == this.GetType() 
                && Equals((HandEvaluationObject)other);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException("Don't need for this application");
            unchecked // the ID should be unique
            {
                int hash = 17;
                hash = hash * 23 + ID.GetHashCode();
                return hash;
            }
        }

        public int CompareTo(HandEvaluationObject other)
        {
            if (other == null) return 1;
            if (this > other) return 1;
            if (this < other) return -1;
            return 0;
        } 

        public static bool operator >(  HandEvaluationObject h1,
                                        HandEvaluationObject h2)
        {
            return h1.IsStrongerThan(h2);
        }

        public static bool operator <(HandEvaluationObject h1,
                                        HandEvaluationObject h2)
        {
            return h2.IsStrongerThan(h1);
        }

        public static bool operator >=(HandEvaluationObject h1,
                                        HandEvaluationObject h2)
        {
            return h1 > h2 || h1 == h2;
        }

        public static bool operator <=(HandEvaluationObject h1,
                                        HandEvaluationObject h2)
        {
            return h1 < h2 || h1 == h2;
        }

        /// <summary>
        /// Returns bool representing if this hand beats the given hand
        /// </summary>
        /// <param name="other"></param>
        /// <returns>true if this hand is stronger than the given hand</returns>
        public bool IsStrongerThan(HandEvaluationObject other)
        {
            if (this.Rank > other.Rank) return true;
            if (this.Rank < other.Rank) return false;
            // rank is equal
            if (this.RankHighCard > other.RankHighCard) return true;
            if (this.RankHighCard < other.RankHighCard) return false;
            // rank is equal with equal rank value
            // we can also assume that the unranked cards lists are equal length
            for(int ii = 0; ii < this.UnrankedCardValues.Count; ii++)
            {
                int diff = (int)(this.UnrankedCardValues.ElementAt(ii)) 
                    - (int)(other.UnrankedCardValues.ElementAt(ii));
                if (diff > 0) return true;
                if (diff < 0) return false;
            }
            // is a tie
            return false;
        }

        /// <summary>
        /// compares the evaluation object and returns the value of the card
        /// that is responsible for winning. Returns Joker in case of tie.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>card that determines winner. If there is a tie returns Joker.</returns>
        public static CardValue GetWinningCard(HandEvaluationObject h1, HandEvaluationObject h2)
        {
            // this wins by hand rank or value
            if (h1.Rank > h2.Rank || 
                (h1.Rank == h2.Rank && h1.RankHighCard > h2.RankHighCard))
            {
                return h1.RankHighCard;
            }
            // other wins by hand rank or value
            if(h2.Rank > h1.Rank ||
                (h2.Rank == h1.Rank && h2.RankHighCard > h1.RankHighCard))
            {
                return h2.RankHighCard;
            }
            // rank and rank value are equal
            // search non contributing cards
            else
            {
                if(h1.UnrankedCardValues.Count != h2.UnrankedCardValues.Count)
                {
                    throw new ArgumentException("Card Hands not comparable. "
                        + "Must have equal number of cards");
                }
                for(int ii = 0; ii < h1.UnrankedCardValues.Count; ii++)
                {
                    if(h1.UnrankedCardValues.ElementAt(ii) 
                        > h2.UnrankedCardValues.ElementAt(ii))
                    {
                        return h1.UnrankedCardValues.ElementAt(ii);
                    }
                    else if (h1.UnrankedCardValues.ElementAt(ii)
                        < h2.UnrankedCardValues.ElementAt(ii))
                    {
                        return h2.UnrankedCardValues.ElementAt(ii);
                    }
                }
            }
            
            return CardValue.Joker;
        }

        private void EvaluateStrength()
        {
            
            if (EvaluateStraightOrFlush()) // evaluated true, finished setting
                return;

            // is not straight or flush
            int[] cardCount = new int[13];
            foreach(Card card in cards)
            {
                int index = (int)card.Value - (int)CardValue.Two;
                cardCount[index]++;
            }
            // is a 4 of a kind?
            if(cardCount.Contains(4))
            {
                rank = HandRank.Four_of_a_Kind;
                rankHighCard = (CardValue)(Array.IndexOf(cardCount, 4) + 1);
                unranked_card_values.Add((CardValue)(Array.IndexOf(cardCount, 1) + 1));
                return;
            }
            // is full house?
            if(cardCount.Contains(3) && cardCount.Contains(2))
            {
                rank = HandRank.Full_House;
                rankHighCard = (CardValue)(Array.IndexOf(cardCount, 3) + 1);
                unranked_card_values.Add((CardValue)(Array.IndexOf(cardCount, 2) + 1));
                return;
            }
            // is three of a kind?
            if(cardCount.Contains(3))
            {
                rank = HandRank.Three_of_a_Kind;
                rankHighCard = (CardValue)(Array.IndexOf(cardCount, 3) + 1);
                int index = Array.IndexOf(cardCount, 1);
                cardCount[index] = 0;
                unranked_card_values.Add((CardValue)(Array.IndexOf(cardCount, 1) + 1));
                unranked_card_values.Add((CardValue)(index + 1));
                return;
            }
            // is at least one pair?
            if(cardCount.Contains(2))
            {
                int lowPairIndex = Array.IndexOf(cardCount, 2);
                cardCount[lowPairIndex] = 0;
                // if two pair?
                if (cardCount.Contains(2))
                {
                    rank = HandRank.Two_Pair;
                    rankHighCard = (CardValue)(Array.IndexOf(cardCount, 2) + 1);
                    // add second pair value
                    unranked_card_values.Add((CardValue)lowPairIndex + 1);
                    // add last card
                    unranked_card_values.Add((CardValue)(Array.IndexOf(cardCount, 1) + 1));
                    return;
                }
                // was just the one  :(
                rank = HandRank.Pair;
                rankHighCard = (CardValue)(lowPairIndex + 1);
                // add unhelpful cards >:(
                for(int ii = cardCount.Length -1; ii >= 0; ii--)
                {
                    if(cardCount[ii] == 1)
                    {
                        unranked_card_values.Add((CardValue)ii + 1);
                    }
                }
                return;
            }
            else // no hands made, just order the high cards
            {
                for(int ii = cardCount.Length - 1; ii >= 0; ii--)
                {
                    if(cardCount[ii] == 1)
                    {
                        if(rank < HandRank.High_Card) // haven't set yet
                        {
                            rank = HandRank.High_Card;
                            rankHighCard = (CardValue)(ii + 1);
                        }
                        else
                        {
                            unranked_card_values.Add((CardValue)(ii + 1));
                        }
                    }
                }
            }
        }

        private bool EvaluateStraightOrFlush()
        {
            bool isFlush = IsFlush();
            bool isStraight = IsStraight();
            CardValue highCard = cards.ElementAt(0).Value;
            
            // is straight or royal flush?
            if (isFlush && isStraight)
            {
                // is royal flush?
                if (highCard == CardValue.Ace)
                {
                    // is royal flush
                    rank = HandRank.Royal_Flush;
                    
                }
                else // is straight flush
                {
                    rank = HandRank.Straight_Flush;
                    
                }
                rankHighCard = highCard;
                unranked_card_values.Clear(); // no remaining cards
                return true;
            }
            // is Flush?
            if(isFlush)
            {
                rank = HandRank.Flush;
                rankHighCard = highCard;
                // in case of tie, the high cards win
                bool afterFirst = false;
                foreach(Card card in cards)
                {
                    if(afterFirst)
                        unranked_card_values.Add(card.Value);
                    else { afterFirst = true; }
                }
                return true;
            }
            // is Straight?
            if(isStraight)
            {
                rank = HandRank.Straight;
                rankHighCard = highCard;
                // no cards, in case of tie card values are all same
                unranked_card_values.Clear();
                return true;
            }
            return false;
        }

        private bool IsFlush()
        {
            CardSuit suit = cards.ElementAt(0).Suit;
            foreach (Card card in cards)
            {
                if (card.Suit != suit)
                    return false;
            }
            return true;
        }

        private bool IsStraight()
        {
            bool afterFirst = false;
            CardValue lastValue = CardValue.Joker;
            foreach(Card card in cards)
            {
                if(afterFirst)
                {
                    if ((int)card.Value - (int)lastValue != -1)
                        return false;
                    lastValue = card.Value;
                }
                else
                {
                    lastValue = card.Value;
                    afterFirst = true;
                }
            }
            return true;
        }

        public string ID
        {
            get { return id; }
            private set { id = value; }
        }
        private string id;
        public CardValue RankHighCard
        {
            get { return rankHighCard; }
            private set { rankHighCard = value; }
        }
        private CardValue rankHighCard;
        public HandRank Rank
        {
            get { return rank; }
            private set { rank = value; }
        }
        private HandRank rank;
        public List<CardValue> UnrankedCardValues
        {
            get { return unranked_card_values; }
            private set { }
        }
        private List<CardValue> unranked_card_values;
        private List<Card> cards;
        
    }
}
