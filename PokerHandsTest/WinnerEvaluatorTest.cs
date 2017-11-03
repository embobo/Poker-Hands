using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHands;

namespace PokerHandsTest
{
    [TestClass]
    public class WinnerEvaluatorTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Unequal player card counts were allowed")]
        public void GetWinner_PlayersWithInequalCardCounts_ThrowsException()
        {
            CardHand player1 = new CardHand("player1");
            CardHand player2 = new CardHand("player2");
            // give player1 five cards
            player1.AddCard(new Card(CardValue.King, CardSuit.Spade));
            player1.AddCard(new Card(CardValue.Queen, CardSuit.Club));
            player1.AddCard(new Card(CardValue.Jack, CardSuit.Heart));
            player1.AddCard(new Card(CardValue.Ten, CardSuit.Club));
            player1.AddCard(new Card(CardValue.Nine, CardSuit.Club));

            // give player2 two cards
            player2.AddCard(new Card(CardValue.King, CardSuit.Heart));
            player2.AddCard(new Card(CardValue.Queen, CardSuit.Diamond));

            List<WinnerSummary> winnerSummary 
                = WinnerEvaluator.GetWinnerOfTwo(player1, player2);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Players with no cards were allowed")]
        public void GetWinner_PlayersHaveNoCards_ThrowsException()
        {
            CardHand player1 = new CardHand("player1");
            CardHand player2 = new CardHand("player2");

            List<WinnerSummary> winnerSummary
                = WinnerEvaluator.GetWinnerOfTwo(player1, player2);
        }


        [TestMethod]
        public void GetWinnerOfTwo_IsTie_GivesTwoWinnerSumamries()
        {
            CardHand player1 = new CardHand("player1");
            CardHand player2 = new CardHand("player2");
            // give player1 straight, King high
            player1.AddCard(new Card(CardValue.King, CardSuit.Spade));
            player1.AddCard(new Card(CardValue.Queen, CardSuit.Club));
            player1.AddCard(new Card(CardValue.Jack, CardSuit.Heart));
            player1.AddCard(new Card(CardValue.Ten, CardSuit.Club));
            player1.AddCard(new Card(CardValue.Nine, CardSuit.Club));

            // give player2 straight, King high
            player2.AddCard(new Card(CardValue.King, CardSuit.Heart));
            player2.AddCard(new Card(CardValue.Queen, CardSuit.Diamond));
            player2.AddCard(new Card(CardValue.Jack, CardSuit.Club));
            player2.AddCard(new Card(CardValue.Ten, CardSuit.Spade));
            player2.AddCard(new Card(CardValue.Nine, CardSuit.Spade));

            List<WinnerSummary> winnerSummary = WinnerEvaluator.GetWinnerOfTwo(player1, player2);
            int result = winnerSummary.Count;
            int expected = 2;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetWinnerOfTwo_SingleWinnerByHandRank_GivesSummary()
        {
            CardHand player1 = new CardHand("player1");
            CardHand player2 = new CardHand("player2");
            // give player1 straight flush
            player1.AddCard(new Card(CardValue.Eight, CardSuit.Spade));
            player1.AddCard(new Card(CardValue.Queen, CardSuit.Spade));
            player1.AddCard(new Card(CardValue.Jack, CardSuit.Spade));
            player1.AddCard(new Card(CardValue.Ten, CardSuit.Spade));
            player1.AddCard(new Card(CardValue.Nine, CardSuit.Spade));

            // give player2 straight, King high
            player2.AddCard(new Card(CardValue.King, CardSuit.Heart));
            player2.AddCard(new Card(CardValue.Queen, CardSuit.Diamond));
            player2.AddCard(new Card(CardValue.Jack, CardSuit.Club));
            player2.AddCard(new Card(CardValue.Ten, CardSuit.Spade));
            player2.AddCard(new Card(CardValue.Nine, CardSuit.Spade));

            List<WinnerSummary> winnerSummaries = WinnerEvaluator.GetWinnerOfTwo(player1, player2);
            WinnerSummary winner = winnerSummaries.ToArray()[0];
            // assert single winner
            Assert.AreEqual(1, winnerSummaries.Count, "Winner Count not correct.");
            Assert.AreEqual("player1", winner.ID, "Winner ID not correct.");
            Assert.AreEqual("Straight Flush", winner.Hand, "Winner rank not correct.");
            Assert.AreEqual(Card.CardValueToShorthand(CardValue.Queen), winner.WinningCard, "Winning card not correct.");
        }

        [TestMethod]
        public void GetWinnerOfTwo_SingleWinnerByRankValue_GivesSummary()
        {
            CardHand player1 = new CardHand("player1");
            CardHand player2 = new CardHand("player2");
            // give player1 straight, Queen high
            player1.AddCard(new Card(CardValue.Eight, CardSuit.Spade));
            player1.AddCard(new Card(CardValue.Queen, CardSuit.Club));
            player1.AddCard(new Card(CardValue.Jack, CardSuit.Heart));
            player1.AddCard(new Card(CardValue.Ten, CardSuit.Club));
            player1.AddCard(new Card(CardValue.Nine, CardSuit.Club));

            // give player2 straight, King high
            player2.AddCard(new Card(CardValue.King, CardSuit.Heart));
            player2.AddCard(new Card(CardValue.Queen, CardSuit.Diamond));
            player2.AddCard(new Card(CardValue.Jack, CardSuit.Club));
            player2.AddCard(new Card(CardValue.Ten, CardSuit.Spade));
            player2.AddCard(new Card(CardValue.Nine, CardSuit.Spade));

            List<WinnerSummary> winnerSummaries = WinnerEvaluator.GetWinnerOfTwo(player1, player2);
            WinnerSummary winner = winnerSummaries.ToArray()[0];
            // assert single winner
            Assert.AreEqual(1, winnerSummaries.Count, "Winner Count not correct.");
            Assert.AreEqual("player2", winner.ID, "Winner ID not correct.");
            Assert.AreEqual("Straight", winner.Hand, "Winner rank not correct.");
            Assert.AreEqual("K", winner.WinningCard, "Winning card not correct.");
        }

        [TestMethod]
        public void GetWinnerOfTwo_SingleWinnerByUnRankedCard_GivesSummary()
        {
            CardHand player1 = new CardHand("player1");
            CardHand player2 = new CardHand("player2");
            // give player1 three of a kind, ten high
            player1.AddCard(new Card(CardValue.Seven, CardSuit.Spade));
            player1.AddCard(new Card(CardValue.Seven, CardSuit.Club));
            player1.AddCard(new Card(CardValue.Seven, CardSuit.Heart));
            player1.AddCard(new Card(CardValue.Ten, CardSuit.Club));
            player1.AddCard(new Card(CardValue.Nine, CardSuit.Club));

            // give player2 three of a kind, ace high
            player2.AddCard(new Card(CardValue.Seven, CardSuit.Heart));
            player2.AddCard(new Card(CardValue.Seven, CardSuit.Diamond));
            player2.AddCard(new Card(CardValue.Seven, CardSuit.Club));
            player2.AddCard(new Card(CardValue.Nine, CardSuit.Spade));
            player2.AddCard(new Card(CardValue.Ace, CardSuit.Spade));

            List<WinnerSummary> winnerSummaries = WinnerEvaluator.GetWinnerOfTwo(player1, player2);
            WinnerSummary winner = winnerSummaries.ToArray()[0];
            // assert single winner
            Assert.AreEqual(1, winnerSummaries.Count, "Winner Count not correct.");
            Assert.AreEqual("player2", winner.ID, "Winner ID not correct.");
            Assert.AreEqual("Three of a Kind", winner.Hand, "Winner rank not correct.");
            Assert.AreEqual("A", winner.WinningCard, "Winning card not correct.");
        }
    }
}
