using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class CardStock: IEnumerable<Card>
    {
        //cards is initalized only in the constructor
        List<Card> Cards { get; set; }
        //constructor initalizing a 26 cards cardstock
        public CardStock()
        {
            Cards = new List<Card>();
            for (int i = 0; i < 13; i++)//how many cards could be here? 26 like in the paper or 28 common sense
            {
                //every number exist in two colors
                Card tmp1 = new Card(E_Color.black, i+1);
                Card tmp2 = new Card(E_Color.red, i+1);
                Cards.Add(tmp1);
                Cards.Add(tmp2);
            }
        }
        //shuffle the card stock
        public void Shuffle()
        {
            Random r = new Random();
            int size = Cards.Count;
            int next;
            for (int i = 0; i < (size / 2); i++)//occurs in half of the ammount
            {
                //maybe to improve to smart shuffle
                next = r.Next(0, size);
                //changing the pointers
                Card tmp = Cards[i];
                Cards[i] = Cards[next];
                Cards[next] = tmp;
            }
        }
        //return all the cards in cards stock
        public override string ToString()
        {
            int size = Cards.Count;
            string name = "";
            for (int i = 0; i < size; i++)
            {
                name = name + (Cards[i]).ToString() + "/n";
            }
            return name;
        }
        //distribute the cards among the players
        public void Distribute(params Player[] players)
        {
            int size = Cards.Count / players.Length;
            foreach (Player p in players)
            {
                
                for (int i = 0; i < size; i++)
                {
                    Card tmp = RemoveCard();
                    p.AddCard(tmp);
                } 
            }
        }
        public Card this[string index]
        {
            get
            {
                //if the card exist
                if (Cards.Exists(x => x.CardName==index))
                {
                    //return the first card that equal to the index
                    return Cards.Find(x => x.CardName == index);
                }
                //the card doesn't exist
                return null;
            }
           
        }
        //sort cards by value
        public void SortCards()
        {
            Cards.Sort();
        }
        //add card to the cardstock
        public void AddCard(Card NewCard)
        {
            Cards.Add(NewCard);
        }
        //remove card from the stock and return it
        public Card RemoveCard()//to ask if it should return a value
        {
            Card tmp = Cards[0];//keep the removed card
            Cards.RemoveAt(0);//remove the first card
            return tmp;
        }
        //ienumerator
        public IEnumerator<Card> GetEnumerator()
        {
            return Cards.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


}
