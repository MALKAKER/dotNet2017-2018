using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    enum E_Color { red , black }
    class Card : IComparable
    {
        //card's color
        private E_Color Color;
        //card's number
        private int Number;
        //Color property simple
        public E_Color MyColor
        {
            get { return Color; }
            set { Color = value; }
        }
        //Number property check if the number isnt in the range otherwise the value is 0
        //throw exeption!
        public int MyNumber
        {
            get { return Number; }
            set { Number = value < 15 && value > 1 ? value : 0; }//where is **0** throw exseption!
        }
        //return the card name in string (2-10 or ace-King)
        public string CardName
        {
            get
            {
                //if it  a regular card, its name is the number
                if (Number > 1 && Number < 11)
                {
                    return Number.ToString();
                }
                //if it a different card , its name is a unique one
                else
                {
                    switch (Number)
                    {
                        case 11:
                            return "Jack";
                        case 12:
                            return "Queen";
                        case 13:
                            return "King";
                        case 1:
                            return "Ace";
                    }
                }
                return "";//**must be exeption**
            }
        }
        //constructor
        public Card(E_Color c = E_Color.black, int n = 1)
        {
            Color = c;
            Number = n;
        }
        //returns the number of the card in CardName format and color
        public override string ToString()
        {
            //**temprary** the regular function
            return CardName + " " + Color;
        }
        //compre according to number,
        //return int >0 if bigger than obj,int <0 if smaller, and int = 0 if eqaul
        public int CompareTo(object obj)
        {
            //compare the numbers on the card
            return (Number.CompareTo((obj as Card).Number));
        }
    }
}
