using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHands;

namespace PokerHandsTest
{
    [TestClass]
    public class HandEvaluationObjectTest
    {
        /* -------------------------------------------------------------------- */
        /* -------------------------- ROYAL FLUSH ----------------------------- */
        /* -------------------------------------------------------------------- */
        [TestMethod]
        public void EvaluateHand_RoyalFlush_RankIsRoyalFlush()
        {
            HandEvaluationObject hand 
                = new HandEvaluationObject(GetRoyalFlush());
            HandRank result = hand.Rank;
            HandRank expected = HandRank.Royal_Flush;

            Assert.AreEqual(expected, result, "Rank of " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_RoyalFlush_RankHighCardIsAce()
        {
            HandEvaluationObject hand 
                = new HandEvaluationObject(GetRoyalFlush());
            CardValue result = hand.RankHighCard;
            CardValue expected = CardValue.Ace;

            Assert.AreEqual(expected, result, "Rank High Card in " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_RoyalFlush_UnRankedCardsIsEmpty()
        {
            HandEvaluationObject hand 
                = new HandEvaluationObject(GetRoyalFlush());
            int result = hand.UnrankedCardValues.Count;
            int expected = 0;

            Assert.AreEqual(expected, result, "Unranked cards in " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }
        /* -------------------------------------------------------------------- */

        /* -------------------------------------------------------------------- */
        /* ------------------------ STRAIGHT FLUSH ---------------------------- */
        /* -------------------------------------------------------------------- */
        [TestMethod]
        public void EvaluateHand_StraightFlush_RankIsStraightFlush()
        {
            HandEvaluationObject hand 
                = new HandEvaluationObject(GetStraightFlush(CardValue.Ten));
            HandRank result = hand.Rank;
            HandRank expected = HandRank.Straight_Flush;

            Assert.AreEqual(expected, result, "Rank of " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_StraightFlush_RankHighCardIsCorrect()
        {
            CardValue expected = CardValue.Jack;
            HandEvaluationObject hand 
                = new HandEvaluationObject(GetStraightFlush(expected));
            CardValue result = hand.RankHighCard;

            Assert.AreEqual(expected, result, "Rank High Card in " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_StraightFlush_UnRankedCardsIsEmpty()
        {
            HandEvaluationObject hand 
                = new HandEvaluationObject(GetStraightFlush(CardValue.Seven));
            int result = hand.UnrankedCardValues.Count;
            int expected = 0;

            Assert.AreEqual(expected, result, "Unranked cards in " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }
        /* -------------------------------------------------------------------- */

        /* -------------------------------------------------------------------- */
        /* ------------------------ FOUR OF A KIND ---------------------------- */
        /* -------------------------------------------------------------------- */
        [TestMethod]
        public void EvaluateHand_FourOfAKind_RankIsFourOfAKind()
        {
            HandEvaluationObject hand
                = new HandEvaluationObject( GetFourOfAKind( CardValue.Four,
                                                            CardValue.Queen) );
            HandRank result = hand.Rank;
            HandRank expected = HandRank.Four_of_a_Kind;

            Assert.AreEqual(expected, result, "Rank of " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_FourOfAKind_RankHighCardIsCorrect()
        {
            CardValue expected = CardValue.Two;
            HandEvaluationObject hand
                = new HandEvaluationObject( GetFourOfAKind( expected,
                                                            CardValue.Queen) );
            CardValue result = hand.RankHighCard;

            Assert.AreEqual(expected, result, "Rank High Card in " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_FourOfAKind_UnRankedCardsIsCorrect()
        {
            HandEvaluationObject hand
                = new HandEvaluationObject( GetFourOfAKind( CardValue.Four,
                                                            CardValue.King) );
            List<CardValue> result = hand.UnrankedCardValues;
            List<CardValue> expected = new List<CardValue>
                ( new CardValue[] { CardValue.King } );
            
            CollectionAssert.AreEqual(expected, result, "Unranked cards in " + hand.ID +
                " expected {" + ListToString(expected) 
                + "} result {" + ListToString(result) + "}" );
        }
        /* -------------------------------------------------------------------- */

        /* -------------------------------------------------------------------- */
        /* -------------------------- FULL HOUSE ------------------------------ */
        /* -------------------------------------------------------------------- */
        [TestMethod]
        public void EvaluateHand_FullHouse_RankIsFullHouse()
        {
            HandEvaluationObject hand
                = new HandEvaluationObject(GetFullHouse(CardValue.Eight,
                                                        CardValue.Three) );
            HandRank result = hand.Rank;
            HandRank expected = HandRank.Full_House;

            Assert.AreEqual(expected, result, "Rank of " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_FullHouse_RankHighCardIsCorrect()
        {
            CardValue expected = CardValue.Two;
            HandEvaluationObject hand
                = new HandEvaluationObject(GetFullHouse(expected,
                                                        CardValue.King));
            CardValue result = hand.RankHighCard;

            Assert.AreEqual(expected, result, "Rank High Card in " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_FullHouse_UnRankedCardsIsCorrect()
        {
            HandEvaluationObject hand
                = new HandEvaluationObject(GetFullHouse(CardValue.Four,
                                                        CardValue.Ace) );
            List<CardValue> result = hand.UnrankedCardValues;
            List<CardValue> expected = new List<CardValue>
                (new CardValue[] { CardValue.Ace });

            CollectionAssert.AreEqual(expected, result, "Unranked cards in " + hand.ID +
                " expected {" + ListToString(expected)
                + "} result {" + ListToString(result) + "}");
        }
        /* -------------------------------------------------------------------- */

        /* -------------------------------------------------------------------- */
        /* ----------------------------- FLUSH -------------------------------- */
        /* -------------------------------------------------------------------- */
        [TestMethod]
        public void EvaluateHand_Flush_RankIsFlush()
        {
            HandEvaluationObject hand
                = new HandEvaluationObject(GetFlush(CardValue.Ten));
            HandRank result = hand.Rank;
            HandRank expected = HandRank.Flush;

            Assert.AreEqual(expected, result, "Rank of " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_Flush_RankHighCardIsCorrect()
        {
            CardValue expected = CardValue.Eight;
            HandEvaluationObject hand
                = new HandEvaluationObject(GetFlush(expected));
            CardValue result = hand.RankHighCard;

            Assert.AreEqual(expected, result, "Rank High Card in " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_Flush_UnRankedCardsIsCorrect()
        {
            HandEvaluationObject hand
                = new HandEvaluationObject(GetFlush(CardValue.Ten));
            List<CardValue> result = hand.UnrankedCardValues;
            List<CardValue> expected = new List<CardValue>
                ( new CardValue[] { CardValue.Five,
                                    CardValue.Four,
                                    CardValue.Three,
                                    CardValue.Two } );

            CollectionAssert.AreEqual(expected, result, "Unranked cards in " + hand.ID +
                " expected {" + ListToString(expected)
                + "} result {" + ListToString(result) + "}");
        }
        /* -------------------------------------------------------------------- */

        /* -------------------------------------------------------------------- */
        /* ---------------------------- STRAIGHT ------------------------------ */
        /* -------------------------------------------------------------------- */
        [TestMethod]
        public void EvaluateHand_Straight_RankIsStraight()
        {
            HandEvaluationObject hand
                = new HandEvaluationObject(GetStraight(CardValue.Jack));
            HandRank result = hand.Rank;
            HandRank expected = HandRank.Straight;

            Assert.AreEqual(expected, result, "Rank of " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_Straight_RankHighCardIsCorrect()
        {
            CardValue expected = CardValue.Queen;
            HandEvaluationObject hand
                = new HandEvaluationObject(GetFlush(expected));
            CardValue result = hand.RankHighCard;

            Assert.AreEqual(expected, result, "Rank High Card in " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_Straight_UnRankedCardsIsEmpty()
        {
            HandEvaluationObject hand
                = new HandEvaluationObject(GetStraight(CardValue.Ten));
            int result = hand.UnrankedCardValues.Count;
            int expected = 0;

            Assert.AreEqual(expected, result, "Unranked cards in " + hand.ID +
                " expected " + expected.ToString()
                + " result " + result.ToString() );
        }
        /* -------------------------------------------------------------------- */

        /* -------------------------------------------------------------------- */
        /* ------------------------ THREE OF A KIND --------------------------- */
        /* -------------------------------------------------------------------- */
        [TestMethod]
        public void EvaluateHand_ThreeOfAKind_RankIsThreeOfAKind()
        {
            HandEvaluationObject hand
                = new HandEvaluationObject(GetThreeOfAKind( CardValue.Six, /* x3 */
                                                            CardValue.Ten, 
                                                            CardValue.Four) );
            HandRank result = hand.Rank;
            HandRank expected = HandRank.Three_of_a_Kind;

            Assert.AreEqual(expected, result, "Rank of " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_ThreeOfAKind_RankHighCardIsCorrect()
        {
            CardValue expected = CardValue.Eight;
            HandEvaluationObject hand
                = new HandEvaluationObject(GetThreeOfAKind (expected,
                                                            CardValue.King,
                                                            CardValue.Three) );
            CardValue result = hand.RankHighCard;

            Assert.AreEqual(expected, result, "Rank High Card in " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_ThreeOfAKind_UnRankedCardsIsCorrect()
        {
            HandEvaluationObject hand
                = new HandEvaluationObject(GetThreeOfAKind( CardValue.Four, /* x3 */
                                                            CardValue.Ace,
                                                            CardValue.Two) );
            List<CardValue> result = hand.UnrankedCardValues;
            List<CardValue> expected = new List<CardValue>
                (new CardValue[] { CardValue.Ace, CardValue.Two });

            CollectionAssert.AreEqual(expected, result, "Unranked cards in " + hand.ID +
                " expected {" + ListToString(expected)
                + "} result {" + ListToString(result) + "}");
        }
        /* -------------------------------------------------------------------- */

        /* -------------------------------------------------------------------- */
        /* --------------------------- TWO PAIR ------------------------------- */
        /* -------------------------------------------------------------------- */
        [TestMethod]
        public void EvaluateHand_TwoPair_RankIsTwoPair()
        {
            HandEvaluationObject hand
                = new HandEvaluationObject(GetTwoPair(  CardValue.Jack, /* x2 */
                                                        CardValue.Seven, /* x2 */
                                                        CardValue.Five) );
            HandRank result = hand.Rank;
            HandRank expected = HandRank.Two_Pair;

            Assert.AreEqual(expected, result, "Rank of " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_TwoPair_RankHighCardIsCorrect()
        {
            CardValue expected = CardValue.Nine;
            HandEvaluationObject hand
                = new HandEvaluationObject(GetTwoPair(  CardValue.Six, /* x2 */
                                                        expected, /* x2 */
                                                        CardValue.King) );
            CardValue result = hand.RankHighCard;

            Assert.AreEqual(expected, result, "Rank High Card in " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_TwoPair_UnRankedCardsIsCorrect()
        {
            HandEvaluationObject hand
                = new HandEvaluationObject(GetTwoPair(  CardValue.Seven, /* x2 */
                                                        CardValue.Queen, /* x2 */
                                                        CardValue.Eight) );
            List<CardValue> result = hand.UnrankedCardValues;
            List<CardValue> expected = new List<CardValue>
                (new CardValue[] { CardValue.Seven, CardValue.Eight });

            CollectionAssert.AreEqual(expected, result, "Unranked cards in " + hand.ID +
                " expected {" + ListToString(expected)
                + "} result {" + ListToString(result) + "}");
        }
        /* -------------------------------------------------------------------- */

        /* -------------------------------------------------------------------- */
        /* ----------------------------- PAIR --------------------------------- */
        /* -------------------------------------------------------------------- */
        [TestMethod]
        public void EvaluateHand_Pair_RankIsPair()
        {
            HandEvaluationObject hand
                = new HandEvaluationObject(GetPair (CardValue.Eight, /* x2 */
                                                    CardValue.Ace,
                                                    CardValue.Seven,
                                                    CardValue.Two) );
            HandRank result = hand.Rank;
            HandRank expected = HandRank.Pair;

            Assert.AreEqual(expected, result, "Rank of " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_Pair_RankHighCardIsCorrect()
        {
            CardValue expected = CardValue.Eight;
            HandEvaluationObject hand
                = new HandEvaluationObject(GetPair( expected, /* x2 */
                                                    CardValue.Ace,
                                                    CardValue.Seven,
                                                    CardValue.Two) );
            CardValue result = hand.RankHighCard;

            Assert.AreEqual(expected, result, "Rank High Card in " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_Pair_UnRankedCardsIsCorrect()
        {
            HandEvaluationObject hand
                = new HandEvaluationObject(GetPair( CardValue.Six, /* x2 */
                                                    CardValue.Ace,
                                                    CardValue.Two,
                                                    CardValue.Ten) );
            List<CardValue> result = hand.UnrankedCardValues;
            List<CardValue> expected = new List<CardValue>
                (new CardValue[] {  CardValue.Ace,
                                    CardValue.Ten,
                                    CardValue.Two });

            CollectionAssert.AreEqual(expected, result, "Unranked cards in " + hand.ID +
                " expected {" + ListToString(expected)
                + "} result {" + ListToString(result) + "}");
        }
        /* -------------------------------------------------------------------- */

        /* -------------------------------------------------------------------- */
        /* -------------------------- HIGH CARD ------------------------------- */
        /* -------------------------------------------------------------------- */
        [TestMethod]
        public void EvaluateHand_HighCard_RankIsHighCard()
        {
            CardHand cards = new CardHand("High_Card");
            cards.AddCard(new Card(CardValue.Three, CardSuit.Diamond));
            cards.AddCard(new Card(CardValue.Ace, CardSuit.Diamond));
            cards.AddCard(new Card(CardValue.Five, CardSuit.Club));
            cards.AddCard(new Card(CardValue.King, CardSuit.Heart));
            cards.AddCard(new Card(CardValue.Seven, CardSuit.Spade));

            HandEvaluationObject hand = new HandEvaluationObject(cards);
            HandRank result = hand.Rank;
            HandRank expected = HandRank.High_Card;

            Assert.AreEqual(expected, result, "Rank of " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_HighCard_RankHighCardIsCorrect()
        {
            CardValue expected = CardValue.Ace;
            CardHand cards = new CardHand("High_Card");
            cards.AddCard(new Card(CardValue.Three, CardSuit.Diamond));
            cards.AddCard(new Card(expected, CardSuit.Diamond));
            cards.AddCard(new Card(CardValue.Five, CardSuit.Club));
            cards.AddCard(new Card(CardValue.King, CardSuit.Heart));
            cards.AddCard(new Card(CardValue.Seven, CardSuit.Spade));

            HandEvaluationObject hand = new HandEvaluationObject(cards);
            CardValue result = hand.RankHighCard;

            Assert.AreEqual(expected, result, "Rank High Card in " + hand.ID +
                " expected " + expected.ToString() + " result " + result.ToString());
        }

        [TestMethod]
        public void EvaluateHand_HighCard_UnRankedCardsIsCorrect()
        {
            CardHand cards = new CardHand("High_Card");
            cards.AddCard(new Card(CardValue.Three, CardSuit.Diamond));
            cards.AddCard(new Card(CardValue.Ace, CardSuit.Diamond));
            cards.AddCard(new Card(CardValue.Five, CardSuit.Club));
            cards.AddCard(new Card(CardValue.King, CardSuit.Heart));
            cards.AddCard(new Card(CardValue.Seven, CardSuit.Spade));

            HandEvaluationObject hand = new HandEvaluationObject(cards);

            List<CardValue> result = hand.UnrankedCardValues;
            List<CardValue> expected = new List<CardValue>
                (new CardValue[] {  CardValue.King,
                                    CardValue.Seven,
                                    CardValue.Five,
                                    CardValue.Three } );

            CollectionAssert.AreEqual(expected, result, "Unranked cards in " + hand.ID +
                " expected {" + ListToString(expected)
                + "} result {" + ListToString(result) + "}");
        }
        /* -------------------------------------------------------------------- */

        
        [TestMethod]
        public void IsStrongerThan_EqualHand_IsFalse()
        {
            HandEvaluationObject h1 = new HandEvaluationObject(GetStraight(CardValue.Ten));
            HandEvaluationObject h2 = new HandEvaluationObject(GetStraight(CardValue.Ten));

            bool result = h1.IsStrongerThan(h2);
            bool expected = false;

            Assert.AreEqual(expected, result,
                "expected h1 == h2 " + expected + " result " + result);
        }

        [TestMethod]
        public void IsStrongerThan_RankIsLower_IsFalse()
        {
            HandEvaluationObject h1 = new HandEvaluationObject(GetStraight(CardValue.Ten));
            HandEvaluationObject h2 = new HandEvaluationObject(GetRoyalFlush());

            bool result = h1.IsStrongerThan(h2);
            bool expected = false;

            Assert.AreEqual(expected, result,
                "expected " + h1.ID + " IsStrongerThan " + h2.ID + " = " + expected + ", result " + result);
        }

        [TestMethod]
        public void IsStrongerThan_RankIsHigher_IsTrue()
        {
            HandEvaluationObject h1 = new HandEvaluationObject(GetRoyalFlush());
            HandEvaluationObject h2 = new HandEvaluationObject(GetStraight(CardValue.Ten));
            
            bool result = h1.IsStrongerThan(h2);
            bool expected = true;

            Assert.AreEqual(expected, result,
                "expected " + h1.ID + " IsStrongerThan " + h2.ID + " = " + expected + ", result " + result);
        }

        [TestMethod]
        public void IsStrongerThan_RankIsEqualRankHighCardIsGreater_IsTrue()
        {
            HandEvaluationObject h1 = new HandEvaluationObject(GetStraight(CardValue.Ten));
            HandEvaluationObject h2 = new HandEvaluationObject(GetStraight(CardValue.Eight));

            bool result = h1.IsStrongerThan(h2);
            bool expected = true;

            Assert.AreEqual(expected, result,
                "expected " + h1.ID + " IsStrongerThan " + h2.ID + " = " + expected + ", result " + result);
        }

        [TestMethod]
        public void IsStrongerThan_RankIsEqualRankHighCardIsLesser_IsFalse()
        {
            HandEvaluationObject h1 = new HandEvaluationObject(GetStraight(CardValue.Ten));
            HandEvaluationObject h2 = new HandEvaluationObject(GetStraight(CardValue.Queen));

            bool result = h1.IsStrongerThan(h2);
            bool expected = false;

            Assert.AreEqual(expected, result,
                "expected " + h1.ID + " IsStrongerThan " + h2.ID + " = " + expected + ", result " + result);
        }

        [TestMethod]
        public void IsStrongerThan_WinByUnRankedHighCard_IsTrue()
        {
            HandEvaluationObject h1 
                = new HandEvaluationObject(GetThreeOfAKind(
                    CardValue.Queen, /* x3 */
                    CardValue.Eight,
                    CardValue.Ace) );
            HandEvaluationObject h2
                = new HandEvaluationObject(GetThreeOfAKind(
                    CardValue.Queen, /* x3 */
                    CardValue.Ace,
                    CardValue.Six));

            bool result = h1.IsStrongerThan(h2);
            bool expected = true;

            Assert.AreEqual(expected, result,
                "expected " + h1.ID + " IsStrongerThan " + h2.ID + " = " + expected + ", result " + result);
        }

        [TestMethod]
        public void IsStrongerThan_LoseByUnRankedHighCard_IsTrue()
        {
            HandEvaluationObject h1
                = new HandEvaluationObject(GetThreeOfAKind(
                    CardValue.Queen, /* x3 */
                    CardValue.Two,
                    CardValue.Ace));
            HandEvaluationObject h2
                = new HandEvaluationObject(GetThreeOfAKind(
                    CardValue.Queen, /* x3 */
                    CardValue.Ace,
                    CardValue.Six));

            bool result = h1.IsStrongerThan(h2);
            bool expected = false;

            Assert.AreEqual(expected, result,
                "expected " + h1.ID + " IsStrongerThan " + h2.ID + " = " + expected + ", result " + result);
        }

        [TestMethod]
        public void CompareTo_OrderList_DescendingOrder()
        {
            HandEvaluationObject h1
                = new HandEvaluationObject(GetThreeOfAKind(
                    CardValue.Queen, /* x3 */
                    CardValue.Two,
                    CardValue.Ace));
            HandEvaluationObject h2 
                = new HandEvaluationObject(GetRoyalFlush());
            HandEvaluationObject h3 
                = new HandEvaluationObject(GetStraight(
                    CardValue.Ace) );
            HandEvaluationObject h4
                = new HandEvaluationObject(GetThreeOfAKind(
                    CardValue.Queen, /* x3 */
                    CardValue.Nine,
                    CardValue.Three));

            List < HandEvaluationObject > result 
                = new List<HandEvaluationObject>();
            result.Add(h1);
            result.Add(h2);
            result.Add(h3);
            result.Add(h4);
            result.Sort();
            result.Reverse();
            List<HandEvaluationObject> expected 
                = new List<HandEvaluationObject>();
            expected.Add(h2);
            expected.Add(h3);
            expected.Add(h1);
            expected.Add(h4);

            CollectionAssert.AreEqual(expected, result,
                "expected list order did not match result");
        }

        [TestMethod]
        public void GetWinningCard_UnEqualRank_IsCorrect()
        {
            HandEvaluationObject h1
                = new HandEvaluationObject(GetStraight(
                    CardValue.Jack));
            HandEvaluationObject h2
                = new HandEvaluationObject(GetThreeOfAKind(
                    CardValue.Queen, /* x3 */
                    CardValue.Nine,
                    CardValue.Three));
            CardValue result = HandEvaluationObject.GetWinningCard(h1, h2);
            CardValue expected = CardValue.Jack;

            Assert.AreEqual(expected, result,
                h1.ID + " vs " + h2.ID
                + " winning card expected " + expected.ToString()
                + " result " + result.ToString());
        }

        [TestMethod]
        public void GetWinningCard_EqualRankUnEqualRankValue_IsCorrect()
        {
            CardValue highCard = CardValue.Ace;
            HandEvaluationObject h1
                = new HandEvaluationObject(GetFullHouse(
                    CardValue.Eight, /* x3 */
                    highCard /* x2 */ ));
            HandEvaluationObject h2
                = new HandEvaluationObject(GetFullHouse(
                    CardValue.Eight, /* x3 */
                    CardValue.Five /* x2 */ ));
            CardValue result = HandEvaluationObject.GetWinningCard(h1, h2);
            CardValue expected = highCard;

            Assert.AreEqual(expected, result,
                h1.ID + " vs " + h2.ID
                + " winning card expected " + expected.ToString()
                + " result " + result.ToString());
        }

        [TestMethod]
        public void GetWinningCard_WinByUnrankedCard_IsCorrect()
        {
            HandEvaluationObject h1
                = new HandEvaluationObject(GetThreeOfAKind(
                    CardValue.Queen, /* x3 */
                    CardValue.King,
                    CardValue.Nine));
            HandEvaluationObject h2
                = new HandEvaluationObject(GetThreeOfAKind(
                    CardValue.Queen, /* x3 */
                    CardValue.Nine,
                    CardValue.Three));
            CardValue result = HandEvaluationObject.GetWinningCard(h1, h2);
            CardValue expected = CardValue.King;

            Assert.AreEqual(expected, result,
                h1.ID + " vs " + h2.ID
                + " winning card expected " + expected.ToString()
                + " result " + result.ToString());
        }

        /* ------------------- HELPERS ---------------------- */

        private CardHand GetRoyalFlushOrdered()
        {
            CardHand hand = new CardHand("Royal_Flush_Ordered_Test");
            hand.AddCard(new Card(CardValue.Ace, CardSuit.Heart));
            hand.AddCard(new Card(CardValue.King, CardSuit.Heart));
            hand.AddCard(new Card(CardValue.Queen, CardSuit.Heart));
            hand.AddCard(new Card(CardValue.Jack, CardSuit.Heart));
            hand.AddCard(new Card(CardValue.Ten, CardSuit.Heart));
            return hand;
        }

        private CardHand GetRoyalFlush()
        {
            CardHand hand = new CardHand("Royal_Flush_Test");
            hand.AddCard(new Card(CardValue.Ten, CardSuit.Heart));
            hand.AddCard(new Card(CardValue.Queen, CardSuit.Heart));
            hand.AddCard(new Card(CardValue.Jack, CardSuit.Heart));
            hand.AddCard(new Card(CardValue.Ace, CardSuit.Heart));
            hand.AddCard(new Card(CardValue.King, CardSuit.Heart));
            return hand;
        }

        private CardHand GetStraightFlush(CardValue highCard)
        {
            CardHand hand = new CardHand("Straight_Flush_Test");
            CardValue lowCard = highCard - 4;
            for(int ii = 0; ii < 5; ii++)
            {
                if(ii % 2 == 0)
                {
                    hand.AddCard(new Card(highCard,CardSuit.Heart));
                    highCard--;
                }
                else
                {
                    hand.AddCard(new Card(lowCard, CardSuit.Heart));
                    lowCard++;
                }
            }
            return hand;
        }

        private CardHand GetFlush(CardValue highCard)
        {
            CardHand hand = new CardHand("Flush_Test");
            hand.AddCard(new Card(CardValue.Three, CardSuit.Heart));
            hand.AddCard(new Card(CardValue.Five, CardSuit.Heart));
            hand.AddCard(new Card(CardValue.Two, CardSuit.Heart));
            hand.AddCard(new Card(highCard, CardSuit.Heart));
            hand.AddCard(new Card(CardValue.Four, CardSuit.Heart));
            return hand;
        }

        private CardHand GetStraight(CardValue highCard)
        {
            CardHand hand = new CardHand("Straight_Test_"
                + highCard.ToString() + "High");
            CardSuit suit = CardSuit.Club;

            for (CardValue cardValue = highCard - 4; cardValue <= highCard; cardValue++)
            {
                suit++;
                hand.AddCard(new Card(cardValue, suit));
                if (suit >= CardSuit.Spade) suit = CardSuit.Club;
            }
            return hand;
        }

        private CardHand GetFourOfAKind(CardValue highCard, CardValue otherCard)
        {
            CardHand hand = new CardHand("Four_Of_A_Kind_"
                + highCard.ToString() + "x4_" + otherCard.ToString());
            CardSuit suit = CardSuit.Diamond;

            for(int ii = 0; ii < 4; ii++)
            {
                suit++;
                hand.AddCard(new Card(highCard, suit));
                if (suit >= CardSuit.Spade) suit = CardSuit.Club;
            }
            hand.AddCard(new Card(otherCard, suit));
            return hand;
        }

        private CardHand GetFullHouse(CardValue threeValue, CardValue pairValue)
        {
            CardHand hand = new CardHand("Full_House_" 
                + threeValue.ToString() + "x3_" + pairValue.ToString() + "Pair");

            CardSuit suit = CardSuit.Diamond;

            // add set of three
            for (int ii = 0; ii < 3; ii++)
            {
                suit++;
                hand.AddCard(new Card(threeValue, suit));
                if (suit >= CardSuit.Spade) suit = CardSuit.Club;
            }
            // add one of pair
            hand.AddCard(new Card(pairValue, suit));
            suit++;
            if (suit >= CardSuit.Spade) suit = CardSuit.Club;
            // add second of pair
            hand.AddCard(new Card(pairValue, suit));
            return hand;
        }


        private CardHand GetThreeOfAKind(   CardValue threeValue, 
                                            CardValue otherValue1,
                                            CardValue otherValue2 )
        {
            CardHand hand = new CardHand(   "Three_of_a_kind_"
                                            + threeValue.ToString() + "x3_"
                                            + otherValue1.ToString() 
                                            + otherValue2.ToString() );

            CardSuit suit = CardSuit.Diamond;

            // add set of three
            for (int ii = 0; ii < 3; ii++)
            {
                suit++;
                hand.AddCard(new Card(threeValue, suit));
                if (suit >= CardSuit.Spade) suit = CardSuit.Club;
            }
            // add one of pair
            hand.AddCard(new Card(otherValue1, suit));
            suit++;
            if (suit >= CardSuit.Spade) suit = CardSuit.Club;
            // add second of pair
            hand.AddCard(new Card(otherValue2, suit));
            return hand;
        }


        private CardHand GetTwoPair(CardValue pair1Value,
                                    CardValue pair2Value,
                                    CardValue otherValue)
        {
            CardHand hand = new CardHand( "Two_Pair_"
                                            + pair1Value.ToString() + "Pair_"
                                            + pair2Value.ToString() + "Pair_"
                                            + otherValue.ToString());
            // first pair
            hand.AddCard(new Card(pair1Value, CardSuit.Club));
            hand.AddCard(new Card(pair1Value, CardSuit.Spade));
            // second pair
            hand.AddCard(new Card(pair2Value, CardSuit.Heart));
            hand.AddCard(new Card(pair2Value, CardSuit.Club));
            // other
            hand.AddCard(new Card(otherValue, CardSuit.Heart));
            return hand;
        }


        private CardHand GetPair(CardValue pairValue,
                                    CardValue otherValue1,
                                    CardValue otherValue2,
                                    CardValue otherValue3)
        {
            CardHand hand = new CardHand(   "Pair_"
                                            + pairValue.ToString() + "Pair_"
                                            + otherValue1.ToString()
                                            + otherValue2.ToString()
                                            + otherValue3.ToString() );
            // first pair
            hand.AddCard(new Card(pairValue, CardSuit.Club));
            hand.AddCard(new Card(pairValue, CardSuit.Spade));
            // other
            hand.AddCard(new Card(otherValue1, CardSuit.Heart));
            hand.AddCard(new Card(otherValue2, CardSuit.Heart));
            hand.AddCard(new Card(otherValue3, CardSuit.Club));
            return hand;
        }

        private string ListToString<T>(IEnumerable<T> list)
        {
            string str = "";
            foreach (T item in list)
            {
                str += item + " ";
            }
            return str;
        }
    }
}
