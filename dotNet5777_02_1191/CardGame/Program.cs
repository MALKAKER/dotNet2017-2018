/*targil 2
  id: 316301191
  
   war game
   I prepare the game to more than 2 players*/
using System;
using System.Collections;
using System.Collections.Generic;
namespace CardGame
{
    class Program
    {
        //define number of players
        static int number_of_players = 2;
        //output to the user
        public static IEnumerable print()
        {
            int num = 0;
            for (int i = 0; i < number_of_players; i++)
            {
                num = (i + 1);
                yield return "enter player"+num+" name";
            }
        }
 
        static void Main(string[] args)
        {
            //input
            string[] p = new string[2];
            int i = 0;
            foreach (string item in print())
            {
                Console.WriteLine(item);
                p[i++] = Console.ReadLine();
            }
            //creat a new game
            Game boringGame = new Game(p);
            //print the cards here it more comfortable not to use for loop
            printPlayersState(boringGame);
            //menue
            string choice;
            Console.WriteLine(@"To play the next step press enter
To run the automatic game press 0");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "":
                    gameStep(boringGame,"");
                    break;
                case "0":
                    gameStep(boringGame);
                    break;
                default:
                    break;
            }
            
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
        }
        //manage the game steps for options enter and 0
        private static void gameStep(Game boringGame,string ch=null)
        {
            int num = 1;
            string input = null;
            while (!boringGame.EndGame())
            {
                //print step number 
                Console.WriteLine("step number {0}:",num);
                //doing the step
                boringGame.Step();
                //print player cond.
                printPlayersState(boringGame);
                ++num;
                //check which option the user chose if it enter the next step
                //depends on clicking enter action otherwise the loop continue 
                if (ch!=null)
                {
                    input=Console.ReadLine();
                }
            }
            Console.WriteLine("the big winner is:{0}",boringGame.TheWinner());
            
        }
        //print the player's condition on the game
        private static void printPlayersState(Game boringGame)
        {
            int i;
            for (i = 0; i < number_of_players; i++)
            {
                Console.WriteLine(boringGame.gamePlayer[i]);
            }
        }
    }
}
/*option 0: last step:
step number 6343:
malki:
Number of cards: 24
Jack red
9 red
7 black
2 black
10 black
4 black
King black
5 black
King red
5 red
Queen black
2 red
Jack black
Ace red
8 black
6 black
10 red
6 red
9 black
3 red
7 red
Ace black
Queen red
3 black

peari:
Number of cards: 2
4 red
8 red

step number 6344:
malki:
Number of cards: 25
9 red
7 black
2 black
10 black
4 black
King black
5 black
King red
5 red
Queen black
2 red
Jack black
Ace red
8 black
6 black
10 red
6 red
9 black
3 red
7 red
Ace black
Queen red
3 black
Jack red
4 red

peari:
Number of cards: 1
8 red

step number 6345:
malki:
Number of cards: 26
7 black
2 black
10 black
4 black
King black
5 black
King red
5 red
Queen black
2 red
Jack black
Ace red
8 black
6 black
10 red
6 red
9 black
3 red
7 red
Ace black
Queen red
3 black
Jack red
4 red
9 red
8 red

peari:
Number of cards: 0

the big winner is:malki
press any key to continue...
 */
