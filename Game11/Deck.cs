using System;
using System.Collections.Generic;
using System.Text;

namespace csc350h
{
    public class Deck
    {
        List<Card> cards = new List<Card>();
        public Deck() {
            foreach (Suit s in Enum.GetValues(typeof(Suit))) {
                foreach (Rank r in Enum.GetValues(typeof(Rank))) {
                    cards.Add(new Card(r.ToString(), s.ToString()));

                }
            }
        }
        public int getCardsRemainNum() {
            return cards.Count;
        }
        public bool Empty {
            get {
                return cards.Count == 0;
            }
        }
        public Card TakeTopCard() {
            if (!Empty)
            {
                Card c = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);
                return c;
            }
            else {
                return null;
            }
  
        }
        //Shuffle
        public void shuffle() {
            if (cards.Count !=0) {
                for (int i = 52; i > 0; i--)
                {
                    int a = new Random().Next(0, i);
                    Card c = cards[i - 1];
                    cards[i - 1] = cards[a];
                    cards[a] = c;
                }
            }
        }
        //cut 

        public void cut( List<Card> list) {
           
            
        }
        public void print()
        {
            print(cards);
        }

        //print 
        public void print(List <Card> list) {
            Console.WriteLine(" the cards in the card list is   " );
            foreach (Card c in list) {
                Console.WriteLine(c.Rank+"   " + c.Suit);
            }
            Console.WriteLine(" the number of cards in the deck   " + cards.Count);
        }
        //Recursively find the element equal to 10, replace it! ! ! <Failed test>
        public void switchTwoCardNotEQ10(List<Card> list, bool falg)
        {
            if (falg)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 9; j > 0; j--)
                    {
                        //count card value
                        int a = (int)System.Enum.Parse(typeof(Rank), list[i].Rank) + 1;
                        int b = (int)System.Enum.Parse(typeof(Rank), list[j].Rank) + 1;
                        if (a + b == 10)
                        {
                            list[i] = TakeTopCard();
                            list[j] = TakeTopCard();
                            //Recurse after updating the list
                            switchTwoCardNotEQ10(list, falg);
                        }
                    }
                }
                //Modify the identification symbol flag without waiting for 10
                falg = false;
            }
        }
    }

    /*
    static void Main(string[] args)
    {
        // 1 create a deck object
        Deck deck = new Deck();
        //2shuffle the deck
        deck.shuffle();
        //3create a new card list
        List<Card> list = new List<Card>();
        //4deal 10 cards from the deck and add them into the card list
        for (int i =0; i<10;i++) {
            list.Add(deck.TakeTopCard());
        }
        //5print cards in the card list and ask user select two cards from the list from the command line
        foreach (Card c in list) {
            Console.WriteLine(c.Rank + "    " + c.Suit);
        }
        //6remove the two card from the list if the total value of the two cards equals to 10, and then deal two more cards from the deck and fill the empty slots.
        //7repeat this task until user are not able to find two cards in the card list with total equals 10.
        bool flag = true;
        deck.switchTwoCardNotEQ10(list, flag);

        //8print the cards in the card list and the number of cards in the deck

        deck.print(list);



    }*/
}
