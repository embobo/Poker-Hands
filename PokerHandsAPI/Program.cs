using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using PokerHands;

namespace PokerHandsAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting server on port 8080");
            PokerHandsHttpServer server = new PokerHandsHttpServer(8080);
            server.Start();
            Console.WriteLine("Simple server for poker hands, press any key to quit.");
            Console.ReadKey();
            server.Stop();
        }

        static void ConsoleApp()
        {
            throw new NotImplementedException("nope");
            /*
           if(args.Length % 2 != 0)
           {
               Console.WriteLine("Invalid Arguments. Please input an even number of cards per player");
               Environment.Exit(0);
           }
           */
            Console.WriteLine(intro);

            // get num players
            Console.WriteLine("Please enter number of players and press enter: ");
            string input = Console.ReadLine();
            int numPlayers;
            while (!Int32.TryParse(input, out numPlayers)
                || !(numPlayers > 0 && numPlayers <= 5))
            {
                Console.WriteLine("Invalid Input.\n"
                    + "Please enter number of players and press enter: ");
                input = Console.ReadLine();
            }

            // get num cards per player
            Console.WriteLine("Please enter number of cards per player and press enter: ");
            input = Console.ReadLine();
            int numCards;
            while (!Int32.TryParse(input, out numCards)
                || !(numCards > 0 && numCards <= 5))
            {
                Console.WriteLine("Invalid Input.\n"
                    + "Please enter number of players and press enter: ");
                input = Console.ReadLine();
            }
        }

        private static string intro = "-- Poker Hand Evaluator --\n"
                + "\n"
                + "This Evaluator allows you to compare up to 5 players.\n"
                + "It returns the winner's name, hand, and winning card.\n"
                + "All players must have an equal number of cards, with a\n"
                + "maximum of 5.\n"
                + "\n"
                + "Player IDs should be unique, but uniqueness is not \n"
                + "enforced.\n"
                + "Cards must be entered in shorthand form. For example:\n"
                + "Ace of Hearts = 'AH'  (A = Ace, H = Hearts)\n"
                + "Ten of Spades = '10S' (10 = Ten, S = Spades)\n"
                + "\n";
    }
}
