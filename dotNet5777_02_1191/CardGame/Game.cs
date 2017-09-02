using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class Game
    {
        private CardStock jackpot;
        public Player[] gamePlayer;
        //constructor which is reset the game
        public Game(params string[] p)
        {
            //prepare the jackpot to contain all the cards
            jackpot = new CardStock();
            jackpot.Shuffle();
            //initalizing n players here in 2
            gamePlayer = new Player[p.Length];
            int i = 0;
            //initalize the players name as players
            foreach (string person in p)
            {
                gamePlayer[i] = new Player();
                gamePlayer[i].Name=person;
                i++;
            }
            //distribute cards to the players
            jackpot.Distribute(gamePlayer);
        }
        //return the winner name
        public string TheWinner()
        {
            // check if somhow lose the game if niether of them lose the func 
            //return null otherwise return the winner name
            return (gamePlayer[0]).Lose()? gamePlayer[1].Name:((gamePlayer[1]).Lose() ? gamePlayer[0].Name:null);
        }
        //check if the game is over
        public bool EndGame()
        {
            //According to the function theWinner
            return TheWinner() != null;
        }
        //return how many cards every player have
        public override string ToString()
        {
            string name = "";
            for (int i = 0; i < gamePlayer.Length; i++)
            {
                name = name + gamePlayer[i].Name + " have " + (gamePlayer[i].MyCards).Count + " game cards.\n";
            }
            return name;
        }
        //procceed a step in the game
        public void Step()
        {
            int size = gamePlayer.Length;
            List<Card>[] onPlayCards = new List<Card>[size];//its array of list because the "war"
            List<Player> win =new List<Player>();
            Card maxi = new Card();
            Card prs = new Card();
            for (int i = 0; i < size; i++)
            {
                if (!gamePlayer[i].Lose())
                {
                    prs = gamePlayer[i].PopCard();
                    onPlayCards[i] = new List<Card>();
                    onPlayCards[i].Add(prs);
                    //prs is bigger than maxi
                    if (prs.CompareTo(maxi) > 0)
                    {
                        //clear all the prev winner
                        win.Clear();
                        //keep the temperary winner
                        win.Add(gamePlayer[i]);
                        //keep presentor for the higher card
                        maxi = prs;
                    }
                    else if (prs.CompareTo(maxi) == 0)
                    {
                        //keep the temperary additional winner
                        win.Add(gamePlayer[i]);
                    }
                }
            }
            //there is only 1 winner, the winner earn all the cards
            if (win.Count==1)
            {
                for (int i = 0; i < size; i++)
                {
                    win[0].AddCard(onPlayCards[i].ToArray());//because it list...
                }
            }
            //war condition between 2 or more players
            else
            {
                //send to a recursive method that manage the war
                War(onPlayCards,win);  
            }
        }
        //activate when there is a war among/between the players
        public void War(List<Card>[] onGameCards, List<Player> winners)
        {
            int size = gamePlayer.Length;
            List<Player> win = new List<Player>();
            //initalize->the lowest number
            Card maxi = new Card();
            //as above
            Card prs = new Card();
            for (int i = 0; i < size; i++)
            {
                //determines if the player in the war
                if (winners.Contains(gamePlayer[i]) && !gamePlayer[i].Lose())
                {
                    prs = gamePlayer[i].PopCard();
                    onGameCards[i].Add(prs);
                }
                //if the player in the war but finished his cards
                //or he is not in the war
                else
                {
                    int number = onGameCards[i].Count;
                    //if the player is not total loser
                    if (number!=0)
                    {
                        prs = onGameCards[i][number - 1];
                    }
                    else
                    {
                        prs = null;
                    }
                }
                //prs isnt empty
                if (prs!=null)
                {
                    //determines who is the winner right now
                    if (prs.CompareTo(maxi) > 0)//prs is bigger than maxi
                    {
                        win.Clear();//clear all the prev winner
                        win.Add(gamePlayer[i]);//keep the temperary winner
                        maxi = prs;//keep presentor for the higher card
                    }
                    else if (prs.CompareTo(maxi) == 0)
                    {
                        win.Add(gamePlayer[i]);//keep the temperary additional winner
                    }
                }
            }
            //CHECK IF THERE IS A SINGLE WINNER,or the two winners had 13 wars=>both lose 
            if (win.Count == 1 || win.TrueForAll(x => x.Lose()))
            {
                for (int i = 0; i < size; i++)
                {
                    win[0].AddCard(onGameCards[i].ToArray());//because it list...
                }
            }
            //IF THERE ARE WINNERS, REPEAT ON THAT PROCEDURE AGAIN TILL WE HAVE 1 WINNER
            else
            {
                War(onGameCards, win);  //send to a recursive method
            }
        }
    }
}
