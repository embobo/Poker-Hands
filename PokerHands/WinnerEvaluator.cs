using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    /// <summary>
    /// Class for determining the winner of a set of players
    /// </summary>
    public static class WinnerEvaluator
    {
        /// <summary>
        /// Gets the winner given two players.
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <returns>summary of winners. List contains summary of both players in case of tie</returns>
        public static List<WinnerSummary> GetWinnerOfTwo(
            CardHand player1, 
            CardHand player2)
        {
            if(player1.Cards.Count <= 0 || player2.Cards.Count <= 0)
            {
                throw new ArgumentException("players must have cards.");
            }
            if(player1.Cards.Count != player2.Cards.Count)
            {
                throw new ArgumentException("players must have equal number of cards.");
            }

            List<WinnerSummary> winners = new List<WinnerSummary>();
            HandEvaluationObject h1 = new HandEvaluationObject(player1);
            HandEvaluationObject h2 = new HandEvaluationObject(player2);

            // tie
            if(h1 == h2)
            {
                winners.Add(new WinnerSummary(h1.ID, h1.Rank, h1.RankHighCard));
                winners.Add(new WinnerSummary(h2.ID, h2.Rank, h2.RankHighCard));
                return winners;
            }
            // h1 won
            if(h1 > h2)
            {
                winners.Add(new WinnerSummary(h1.ID, h1.Rank, 
                    HandEvaluationObject.GetWinningCard(h1,h2)));
                return winners;
            }
            // else player2 won
            winners.Add(new WinnerSummary(h2.ID, h2.Rank, 
                HandEvaluationObject.GetWinningCard(h1, h2)));
            return winners;
        }

        public static List<WinnerSummary> GetWinners(IEnumerable<CardHand> players)
        {
            throw new NotImplementedException();

            List<HandEvaluationObject> playerHands = new List<HandEvaluationObject>();
            foreach(CardHand player in players)
            {
                playerHands.Add(new HandEvaluationObject(player));
            }
            playerHands.Sort(); // sorts ascending
            playerHands.Reverse(); // reverse to descending
            HandEvaluationObject lastWinner = playerHands.First();
            string lastWinnerID = "";
            CardValue winningCard = CardValue.Joker;
            int checkIndex = 1;
            // while in the list of players and winner is not set
            while(checkIndex < playerHands.Count && winningCard == CardValue.Joker)
            {
                HandEvaluationObject nextPlayer = playerHands.ElementAt(checkIndex);
                // if still a tie
                if ((lastWinner == nextPlayer))
                {
                    lastWinner = nextPlayer;
                    checkIndex++;
                }
                // we finally found the losing player
                else
                {
                    lastWinnerID = lastWinner.ID;
                    // lose by card not in hand rank
                    
                }
            }
        }
    }
}
