using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHands;

namespace PokerHandsTest
{
    [TestClass]
    public class CardHandTest
    {
        [TestMethod]
        public void CardHand_ConstructFromArray_CardsAddCorrectly()
        {
            // create array
            Card[] cards = new Card[5];
            cards[0] = new Card(CardValue.Ace, CardSuit.Spade);
            cards[1] = new Card(CardValue.King, CardSuit.Spade);
            cards[2] = new Card(CardValue.Two, CardSuit.Diamond);
            cards[3] = new Card(CardValue.Queen, CardSuit.Spade);
            cards[4] = new Card(CardValue.Jack, CardSuit.Spade);

            // construct hand
            CardHand cardHand = new CardHand("test_id", cards);

            List<Card> cardList = new List<Card>(cards);

            List<Card> cardsInHand = cardHand.Cards;

            bool result = cardList.Count == cardsInHand.Count;
            if(result) {
                foreach(Card card in cardList)
                {
                    if(!cardsInHand.Contains(card))
                    {
                        result = false;
                        break;
                    }
                }
            }

            bool expected = true;

            Assert.AreEqual(expected, result, 
                "Cards in hand did not match cards provided in array.");
            
        }


        [TestMethod]
        public void AddCard_AddCardsIndividually_CardsAddCorrectly()
        {
            // create array
            Card[] cards = new Card[5];
            cards[0] = new Card(CardValue.Ace, CardSuit.Spade);
            cards[1] = new Card(CardValue.King, CardSuit.Spade);
            cards[2] = new Card(CardValue.Two, CardSuit.Diamond);
            cards[3] = new Card(CardValue.Queen, CardSuit.Spade);
            cards[4] = new Card(CardValue.Jack, CardSuit.Spade);

            // construct hand
            CardHand cardHand = new CardHand("test_id");

            foreach (Card card in cards)
            {
                cardHand.AddCard(card);
            }

            List<Card> cardsInHand = cardHand.Cards;
            List<Card> cardList = new List<Card>(cards);

            bool result = cardList.Count == cardsInHand.Count;
            if (result)
            {
                foreach (Card card in cardList)
                {
                    if (!cardsInHand.Contains(card))
                    {
                        result = false;
                        break;
                    }
                }
            }

            bool expected = true;

            Assert.AreEqual(expected, result,
                "Cards in hand did not match cards provided in array.");

        }


        [TestMethod]
        public void Empty_HandWithCardsEmptiesToZero_IsZero()
        {
            // create array
            Card[] cards = new Card[5];
            cards[0] = new Card(CardValue.Ace, CardSuit.Spade);
            cards[1] = new Card(CardValue.King, CardSuit.Spade);
            cards[2] = new Card(CardValue.Two, CardSuit.Diamond);
            cards[3] = new Card(CardValue.Queen, CardSuit.Spade);
            cards[4] = new Card(CardValue.Jack, CardSuit.Spade);

            // construct hand
            CardHand cardHand = new CardHand("test_id",cards);

            cardHand.Empty();

            int result = cardHand.Cards.Count;
            int expected = 0;

            Assert.AreEqual(expected, result,
                "Card hand did not empty, still contains " + result + " cards\n");
        }


        [TestMethod]
        public void ToString_CardHandPrints_IsCorrect()
        {
            // create array
            Card[] cards = new Card[5];
            cards[0] = new Card(CardValue.Ace, CardSuit.Spade);
            cards[1] = new Card(CardValue.King, CardSuit.Spade);
            cards[2] = new Card(CardValue.Two, CardSuit.Diamond);
            cards[3] = new Card(CardValue.Queen, CardSuit.Club);
            cards[4] = new Card(CardValue.Four, CardSuit.Heart);

            // construct hand
            CardHand cardHand = new CardHand("test_id",cards);

            // get printable string
            string result = cardHand.ToString();
            string expected = "AS, KS, 2D, QC, 4H";

            Assert.AreEqual(expected, result,
                "Card hand did not print, expected: '" + expected 
                + "' got: '" + result + "'\n");
        }
    }
}
