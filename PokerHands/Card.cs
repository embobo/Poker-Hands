using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public enum CardSuit { Joker, Club, Diamond, Heart, Spade };
    public enum CardValue { Joker, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };

    public class Card : IEquatable<Card>,
                        IComparable<Card>
    {
        /// <summary>
        /// Creates a Joker card
        /// </summary>
        public Card()
        {
            this.suit = CardSuit.Joker;
            this.value = CardValue.Joker;
        }

        /// <summary>
        /// Creates a card with given suit and value
        /// </summary>
        /// <param name="suit">The suit</param>
        /// <param name="value">The face value</param>
        public Card(CardSuit suit, CardValue value)
        {
            this.suit = suit;
            this.value = value;
        }

        /// <summary>
        /// Creates a card with given value and suit
        /// </summary>
        /// <param name="value">The face value</param>
        /// <param name="suit">The suit</param>
        public Card(CardValue value, CardSuit suit)
        {
            this.suit = suit;
            this.value = value;
        }

        /// <summary>
        /// Get string representing the card suit and value
        /// </summary>
        /// <returns>String representation of the card (shorthand)</returns>
        public override string ToString()
        {
            return CardValueToShorthand(this.value) + suit.ToString().FirstOrDefault().ToString();
        }

        /// <summary>
        /// Gets a longform representation of the card
        /// </summary>
        /// <example>"Ace of Spades"</example>
        /// <returns>String longform representation of the card</returns>
        public string ToLongformString()
        {
            return value.ToString() + " of " + suit.ToString() + "s";
        }

        public static string CardValueToShorthand(CardValue value)
        {
            switch (value)
            {
                case CardValue.Joker:
                    return "J";
                case CardValue.Two:
                    return "2";
                case CardValue.Three:
                    return "3";
                case CardValue.Four:
                    return "4";
                case CardValue.Five:
                    return "5";
                case CardValue.Six:
                    return "6";
                case CardValue.Seven:
                    return "7";
                case CardValue.Eight:
                    return "8";
                case CardValue.Nine:
                    return "9";
                case CardValue.Ten:
                    return "10";
                case CardValue.Jack:
                    return "J";
                case CardValue.Queen:
                    return "Q";
                case CardValue.King:
                    return "K";
                case CardValue.Ace:
                    return "A";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Strict == where suit and value must be equal
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>true if suits and values are equal</returns>
        public static bool operator ==(Card c1, Card c2)
        {
            if (ReferenceEquals(c1, c2)) return true;
            if (ReferenceEquals(c1, null)) return false;
            if (ReferenceEquals(c2, null)) return false;
            return c1.Suit.Equals(c2.Suit)
                && c1.Value.Equals(c2.Value);
        }

        /// <summary>
        /// Strict != where mismatch of either suit or value will result in true
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>true if either suit or value do not match</returns>
        public static bool operator !=(Card c1, Card c2)
        {
            return !(c1 == c2);
        }

        /// <summary>
        /// Suit and Value compared
        /// </summary>
        /// <param name="other"></param>
        /// <returns>true if suit and value match</returns>
        public bool Equals(Card other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.Suit.Equals(other.Suit)
                && this.Value.Equals(other.Value);
        }

        /// <summary>
        /// Suit and Value compared
        /// </summary>
        /// <param name="other"></param>
        /// <returns>true if suit and value match</returns>
        public override bool Equals (object other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.GetType() == this.GetType()
                && Equals((Card)other);
        }

        /// <summary>
        /// Gets hashcode for card
        /// </summary>
        /// <returns>int hashcode</returns>
        public override int GetHashCode()
        {
            // from Josh Bloch "Effective Java"
            unchecked
            {
                int hash = 17;
                // Suitable nullity checks, etc
                hash = hash * 23 + ((int)suit).GetHashCode();
                hash = hash * 23 + ((int)value).GetHashCode();
                return hash;
            }
        }

        public int CompareTo(Card other)
        {
            if (other == null) return 1;
            if (this > other) return 1;
            if (this < other) return -1;
            return 0;
        }

        /// <summary>
        /// operator less than for Card class.
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>true if value of c1 < c2 
        /// or if c1 == c2 and c1 has lower ranked suit
        /// </returns>
        public static bool operator <(Card c1, Card c2)
        {
            if (c1.Value < c2.Value) return true;
            if (c1.Value == c2.Value && c1.Suit < c2.Suit) return true;
            return false;
        }

        /// <summary>
        /// operator greater than for Card class.
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>true if value of c1 > c2 
        /// or if c1==c2 and c1 has higher ranked suit
        /// </returns>
        public static bool operator >(Card c1, Card c2)
        {
            if (c1.Value > c2.Value) return true;
            if (c1.Value == c2.Value && c1.Suit > c2.Suit) return true;
            return false;
        }

        // operator for <=
        public static bool operator <=(Card c1, Card c2)
        {
            return c1 < c2 || c1 == c2;
        }

        /// <summary>
        /// operator greater than or equal to
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator >=(Card c1, Card c2)
        {
            return c1 > c2 || c1 == c2;
        }

        /// <summary>
        /// Change the card
        /// </summary>
        /// <param name="value"></param>
        /// <param name="suit"></param>
        public void SetCard(CardValue value, CardSuit suit)
        {
            this.suit = suit;
            this.value = value;
        }

        /// <summary>
        /// Card Suit
        /// </summary>
        /// <value>The card's suit</value>
        public CardSuit Suit
        {
            get { return suit; }
            private set { suit = value; }
        }
        private CardSuit suit;

        /// <summary>
        /// Card face value
        /// </summary>
        /// <value>The card's face value</value>
        public CardValue Value
        {
            get { return value; }
            private set { this.value = value; }
        }
        private CardValue value;

    }
}
