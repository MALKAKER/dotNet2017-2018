using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class Player : IComparable
    {
        public string Name = "";
        public Queue<Card> MyCards= new Queue<Card>();
        //add cards to the end of the queue
        public void AddCard(params Card[] moreCards)
        {
            for (int i = 0; i < moreCards.Length; i++)
            {
                MyCards.Enqueue(moreCards[i]);
            }
        }
        //print players name, number of cards per player, the name of the cards
        public override string ToString()
        {
            string name = "";
            name = name + Name+":\nNumber of cards: "+MyCards.Count+"\n";
            foreach (Card item in MyCards)
            {
                name = name + item + "\n";
            }
            return name;

        }
        //return true if the player finished his stock
        public bool Lose()
        {
            return MyCards.Count==0;
        }
        //reduce the number of the player's cards by 1 and return the value
        public Card PopCard()
        {
            return MyCards.Dequeue();
        }
        //compare players's names
        public int CompareTo(object obj)
        {
            //compare if the player is the same player
            return ((Name.CompareTo((obj as Player).Name)));
        }
    }
    
}
