# Poker-Hands
simple poker hand comparator using C# .NET 

## How to Run
1. Open in Visual Studio. 
2. Use Nuget to add library dependencies listed in [Dependencies](#Dependencies).
3. Build.
4. In Command Prompt navigate to the PokerHands\PokerHandsAPI\bin\Debug\ directory
5. In Command Prompt write "PokerHandsAPI" and hit `enter`. This will start the server.
6. In a Web Browser type the URL provided at the startup of the server. This will be something like http://localhost:8080/
7. Append to this "?"
8. Append "player1=" and add the name of your player1.
9. Append "&"
10. To give this player cards Append "cards1="
11. Add cards in shorthand form separated by "+". Up to 5 cards per player.
12. Append "&"
13. Repeat 8-11 with "player2" and "cards2". The players must have equal numbers of cards
14. Append "/" and hit enter

#### Example:
Player1 has a royal flush in Spades and player2 has a straight flush in Clubs, Jack high:

http://localhost:8080/?player1=myName&cards1=AS+KS+QS+JS+10S&player2=otherName&cards2=JC+10C+9C+8C+7C/


## PokerHands
project containing data structures and methods for holding cards, 
processing hand strength, and evaluating the winner of a set of hands.

#### Notes

- If doing this again, I would make the CardValue and CardSuit enums
classes such that they could contain their own methods for string 
conversion

## PokerHandsTest
unit test project for testing the classes in PokerHands.

## PokerHandsAPI
project for running the program and setting up an http listener to get 
and respond to http requests.

## Dependencies
