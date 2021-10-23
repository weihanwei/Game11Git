using System;
using System.Collections.Generic;
using System.Text;

namespace csc350h
{
    public class Hand
    {
        private List<Card> list;
        private int Count;
        private bool empty;

        public Hand()
        {
            list = new List<Card>();
            Count = 0;
            empty = true;
        }
        //draw card pick a card from deck
        public void drawCard(Card c)
        {
            list.Add(c);
        }
        //read the card from hand
        public Card ReadCard(int i)
        {
            return list[i];
        }
        //remove a card
        public void removeCard4Hand(Card a)
        {
            list.Remove(a);
        }
        //is empty
        public bool ISempty()
        {
            return Count ==0;
        }
        public Card getCard() {
            if (ISempty()) {
                return null;
            }
            else {
                return list[0];
            }
        }
        //add card to hand list
        public void addCard(Card C) {
            if (ISempty())
            {
                Console.WriteLine("EMPTY");
            }
            else
            {
                list.Add(C);
            }
           
        }
        // remove card from hand list when the card == 
        public Card removeCard(int i) {
            if (ISempty())
            {
                return null;
            }
            else {
                Card c =list[i];
                list.RemoveAt(i);
                return c;
            }  
        }

        public bool Empty
        {
            get
            {
                return Count == 0;
            }
        }
    }
}

