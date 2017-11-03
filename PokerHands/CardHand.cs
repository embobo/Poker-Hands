using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public class CardHand
    {
        /// <summary>
        /// private default constructor. All hands must be given an ID
        /// </summary>
        private CardHand() { }

        /// <summary>
        /// Constructor for CardHand creates empty hand.
        /// </summary>
        public CardHand(string id)
        {
            this.id = id;
            cards = new List<Card>();
        }

        /// <summary>
        /// Constructs CardHand with given set.
        /// </summary>
        /// <param name="cards">IEnumerable set of cards</param>
        public CardHand(string id, IEnumerable<Card> cards)
        {
            this.id = id;
            this.cards = new List<Card>(cards);
        }

        /// <summary>
        /// Gets a printable string representation of the cards in the hand.
        /// </summary>
        /// <returns>String representing the cards in the hand</returns>
        public override string ToString()
        {
            string hand = "";
            int count = cards.Count;
            foreach(Card card in cards)
            {
                hand += card.ToString();
                count--;
                if(count != 0) hand += ", ";
            }
            return hand;
        }

        /// <summary>
        /// Add Card to hand
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        /// <summary>
        /// Empty the Cards from the hand
        /// </summary>
        public void Empty()
        {
            cards.Clear();
        }

        public string ID
        {
            get { return id; }
            private set { id = value; }
        }
        private string id;

        public List<Card> Cards
        {
            get { return cards; }
            private set { }
        }
        private List<Card> cards;
    }
}
