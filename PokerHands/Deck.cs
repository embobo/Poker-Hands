using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    /// <summary>
    /// Deck of cards
    /// </summary>
    class Deck
    {
        /// <summary>
        /// Returns a list of a full deck
        /// </summary>
        /// <returns></returns>
        /*
        public static Card[] GetFullDeck()
        {
            Card[] fullDeck = new Card[52];
            int ind = 0;
            for(CardSuit suit = CardSuit.Club; suit <= CardSuit.Spade; suit++)
            {
                for(CardValue face = CardValue.Two; face <= CardValue.Ace; face++)
                {
                    fullDeck[ind] = new Card(suit, face);
                    ind++;
                }
            }
            return fullDeck;
        }
        */

        public Deck()
        {
            deck = new List<Card>();
        }

        /// <summary>
        /// Printable string of the deck, with max of 13 cards per line
        /// Cards are separated by ", "
        /// </summary>
        /// <returns>String representation of the deck</returns>
        public override string ToString()
        {
            string str = "";
            int count = deck.Count;
            int maxPerLine = 13;
            int onLine = 0;
            foreach(Card card in deck)
            {
                str += card.ToString();
                count--;
                onLine++;
                if(count != 0)
                {
                    str += ", ";
                }
                if(onLine == maxPerLine)
                {
                    str += "\n";
                    onLine = 0;
                }
            }
            return str;
        }

        private List<Card> deck;
    }
}
