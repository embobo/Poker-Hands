using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PokerHands
{
    /// <summary>
    /// Provides data about the game winner
    /// </summary>
    [Serializable]
    public class WinnerSummary  : ISerializable
    {
        /// <summary>
        /// Create a summary of winning player
        /// </summary>
        /// <param name="id">id of player</param>
        /// <param name="hand">player's best hand</param>
        /// <param name="winningCard">card responsible for win</param>
        public WinnerSummary(   string id, 
                                HandRank hand, 
                                CardValue winningCard )
        {
            this.id = id;
            this.hand = EnumStringParsers.HandRankToString(hand);
            this.winningCard = Card.CardValueToShorthand(winningCard);
        }

        public override string ToString()
        {
            return ID + " with " + hand.ToString() + ", " 
                + winningCard + " high";
        }

        /// <summary>
        /// for serializing the data
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //info.AddValue("id",)
        }

        /// <summary>
        /// Winning card
        /// </summary>
        /// <value>Card responsible for win</value>
        public string WinningCard
        {
            get { return winningCard; }
            private set { winningCard = value; }
        }
        private string winningCard;

        /// <summary>
        /// Best hand the player made
        /// </summary>
        /// <value>Best hand of the player's cards</value>
        public string Hand
        {
            get { return hand; }
            private set { hand = value; }
        }
        private string hand;
        
        /// <summary>
        /// ID of player
        /// </summary>
        /// <value>Player id</value>
        public string ID
        {
            get { return id; }
            private set { id = value; }
        }
        private string id;
    }
}
