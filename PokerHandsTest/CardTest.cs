using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHands;

namespace PokerHandsTest
{
    [TestClass]
    public class CardTest
    {

        // -------------- Test Stringifies ----------------  //

        /// <summary>
        /// Tests the cards ToString method on face valued card
        /// </summary>
        [TestMethod]
        public void ToString_FaceValuedCard_PrintsSuccessfully()
        {
            // create Ace of Spades
            Card testCard = new Card(CardValue.Ace, CardSuit.Spade);
            String result = testCard.ToString();
            String expected = "AS";

            Assert.AreEqual(expected, result, false,
                            "card not displayed correctly - " 
                                + "\n\texpected: '" + expected 
                                + "' got: '" + result + "'"
                                + ".\n" );
        }

        /// <summary>
        /// Tests the cards ToString method on numeric valued card
        /// </summary>
        [TestMethod]
        public void ToString_NumericValuedCard_PrintsSuccessfully()
        {
            // create Ace of Spades
            Card testCard = new Card(CardValue.Six, CardSuit.Heart);
            String result = testCard.ToString();
            String expected = "6H";

            Assert.AreEqual(expected, result, false,
                            "card not displayed correctly - "
                                + "\n\texpected: '" + expected
                                + "' got: '" + result + "'"
                                + ".\n");
        }

        /// <summary>
        /// Tests the cards ToString method on numeric valued card
        /// </summary>
        [TestMethod]
        public void ToLongFormString_ValuedCard_PrintsSuccessfully()
        {
            // create Ace of Spades
            Card testCard = new Card(CardValue.Seven, CardSuit.Club);
            String result = testCard.ToLongformString();
            String expected = "Seven of Clubs";

            Assert.AreEqual(expected, result, false,
                            "card not displayed correctly - "
                                + "\n\texpected: '" + expected
                                + "' got: '" + result + "'"
                                + ".\n");
        }

        // -------------- Test Value Setting ------------------ //
        [TestMethod]
        public void SetCard_DefaultGivenValues_NewValuesStick()
        {
            Card testCard = new Card();
            testCard.SetCard(CardValue.Eight, CardSuit.Heart);
        }

        // -------------- Test Operators and Equatables ------ //

        [TestMethod]
        public void CompareTo_EqualCard_IsZero()
        {
            Card c1 = new Card(CardSuit.Club, CardValue.Ace);
            Card c2 = new Card(CardSuit.Club, CardValue.Ace);
            bool result = c1.CompareTo(c2) == 0;
            bool expected = true;

            Assert.AreEqual(expected, result,
                            "expected c1 == c2: " + expected + " result: " + result);
        }

        [TestMethod]
        public void CompareTo_GreaterCard_IsNegative()
        {
            Card c1 = new Card(CardSuit.Heart, CardValue.Two);
            Card c2 = new Card(CardSuit.Club, CardValue.Ace);
            bool result = c1.CompareTo(c2) < 0;
            bool expected = true;

            Assert.AreEqual(expected, result,
                            "expected c1 < c2: " + expected + " result: " + result);
        }

        [TestMethod]
        public void CompareTo_LesserCard_IsPositive()
        {
            Card c1 = new Card(CardSuit.Club, CardValue.Six);
            Card c2 = new Card(CardSuit.Spade, CardValue.Four);
            bool result = c1.CompareTo(c2) > 0;
            bool expected = true;

            Assert.AreEqual(expected, result,
                            "expected c1 > c2: " + expected + " result: " + result);
        }

        [TestMethod]
        public void Equals_EqualReferenceCard_IsTrue()
        {
            Card c1 = new Card(CardValue.Two, CardSuit.Diamond);
            Boolean result = c1.Equals(c1);
            Boolean expected = true;

            Assert.AreEqual(expected, result, 
                            c1.ToString() + " not found equal to itself.\n");
        }

        /// <summary>
        /// Tests the cards 'Equals()' method when
        /// card is compared to equal card. (same suit and value)
        /// </summary>
        [TestMethod]
        public void Equals_EqualValueEqualSuitCards_IsTrue()
        {
            Card c1 = new Card(CardSuit.Diamond, CardValue.Two);
            Card c2 = new Card(CardSuit.Diamond, CardValue.Two);
            Boolean result = c1.Equals(c2);
            Boolean expected = true;

            Assert.AreEqual(expected, result, 
                            c1.ToString() + " not found equal to " + c2.ToString());
        }

        /// <summary>
        /// Tests the cards 'Equals()' method when
        /// card is compared to card with different value
        /// </summary>
        [TestMethod]
        public void Equals_UnEqualValueEqualSuitCards_IsFalse()
        {
            Card c1 = new Card(CardSuit.Heart, CardValue.Two);
            Card c2 = new Card(CardSuit.Heart, CardValue.Ten);
            Boolean result = c1.Equals(c2);
            Boolean expected = false;

            Assert.AreEqual(expected, result, 
                            c1.ToString() + " found equal to " + c2.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void IsEquals_EqualValueUnEqualSuitCards_IsFalse()
        {
            Card c1 = new Card(CardSuit.Heart, CardValue.Ten);
            Card c2 = new Card(CardSuit.Spade, CardValue.Ten);
            Boolean result = c1.Equals(c2);
            Boolean expected = false;

            Assert.AreEqual(expected, result, 
                            c1.ToString() + " found equal to " + c2.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void OperatorIsEquals_EqualValueEqualSuitCards_IsTrue()
        {
            Card c1 = new Card(CardSuit.Diamond, CardValue.Two);
            Card c2 = new Card(CardSuit.Diamond, CardValue.Two);
            Boolean result = c1 == c2;
            Boolean expected = true;

            Assert.AreEqual(expected, result, 
                            c1.ToString() + " not found equal to " + c2.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void OperatorIsEquals_UnEqualValueEqualSuitCards_IsFalse ()
        {
            Card c1 = new Card(CardSuit.Spade, CardValue.Two);
            Card c2 = new Card(CardSuit.Diamond, CardValue.Ace);
            Boolean result = c1 == c2;
            Boolean expected = false;

            Assert.AreEqual(expected, result, 
                c1.ToString() + " found equal to " + c2.ToString());
        }

        [TestMethod]
        public void OperatorGreaterThan_EqualCards_IsFalse()
        {
            Card c1 = new Card(CardSuit.Spade, CardValue.Two);
            Card c2 = new Card(CardSuit.Spade, CardValue.Two);
            Boolean result = c1 > c2;
            Boolean expected = false;

            Assert.AreEqual(expected, result,
                c1.ToString() + " found greater than " + c2.ToString());
        }

        [TestMethod]
        public void OperatorGreaterThan_Card1ValueGreaterThanCard2_IsTrue()
        {
            Card c1 = new Card(CardSuit.Spade, CardValue.Ace);
            Card c2 = new Card(CardSuit.Spade, CardValue.Two);
            Boolean result = c1 > c2;
            Boolean expected = true;

            Assert.AreEqual(expected, result,
                c1.ToString() + " not found greater than " + c2.ToString());
        }

        [TestMethod]
        public void OperatorGreaterThan_Card1ValueLessThanCard2_IsFalse()
        {
            Card c1 = new Card(CardSuit.Spade, CardValue.Two);
            Card c2 = new Card(CardSuit.Spade, CardValue.Ace);
            Boolean result = c1 > c2;
            Boolean expected = false;

            Assert.AreEqual(expected, result,
                c1.ToString() + " found greater than " + c2.ToString());
        }

        [TestMethod]
        public void OperatorGreaterThan_EqualValueCard1GreaterSuit_IsTrue()
        {
            Card c1 = new Card(CardSuit.Spade, CardValue.Ace);
            Card c2 = new Card(CardSuit.Heart, CardValue.Ace);
            Boolean result = c1 > c2;
            Boolean expected = true;

            Assert.AreEqual(expected, result,
                c1.ToString() + " not found greater than " + c2.ToString());
        }

        [TestMethod]
        public void OperatorLessThan_EqualCards_IsFalse()
        {
            Card c1 = new Card(CardSuit.Spade, CardValue.Two);
            Card c2 = new Card(CardSuit.Spade, CardValue.Two);
            Boolean result = c1 < c2;
            Boolean expected = false;

            Assert.AreEqual(expected, result,
                c1.ToString() + " found less than " + c2.ToString());
        }

        [TestMethod]
        public void OperatorLessThan_Card1ValueLessThanCard2_IsTrue()
        {
            Card c1 = new Card(CardSuit.Spade, CardValue.Five);
            Card c2 = new Card(CardSuit.Spade, CardValue.Six);
            Boolean result = c1 < c2;
            Boolean expected = true;

            Assert.AreEqual(expected, result,
                c1.ToString() + " not found less than " + c2.ToString());
        }

        [TestMethod]
        public void OperatorLessThan_Card1ValueGreaterThanCard2_IsFalse()
        {
            Card c1 = new Card(CardSuit.Spade, CardValue.Nine);
            Card c2 = new Card(CardSuit.Spade, CardValue.Six);
            Boolean result = c1 < c2;
            Boolean expected = false;

            Assert.AreEqual(expected, result,
                c1.ToString() + " found less than " + c2.ToString());
        }

        [TestMethod]
        public void OperatorLessThan_EqualValueCard1LesserSuit_IsTrue()
        {
            Card c1 = new Card(CardSuit.Club, CardValue.Six);
            Card c2 = new Card(CardSuit.Spade, CardValue.Six);
            Boolean result = c1 < c2;
            Boolean expected = true;

            Assert.AreEqual(expected, result,
                c1.ToString() + " not found less than " + c2.ToString());
        }

        
    }
}
