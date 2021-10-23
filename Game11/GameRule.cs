using System;
using System.Collections.Generic;
using System.Text;

namespace csc350h
{
    class GameRule
    {
        public int gameNum; // Game rules target numbers, 10, 11, 13
        public int matchNum;// the cum of the selected Card value
        public int boardCard; // how many card in the table
        public int cardQuinity;//how many card the player can select
        public GameRule() { 
        
        }
        public GameRule(int target, int cardQuinity)
        {
            gameNum = target;
            this.cardQuinity = cardQuinity;
            
            if (target == 11)
            {
                boardCard = 9;
                matchNum = 11;
            }
            else if (target == 10)
            {
                boardCard = 13;
                matchNum = 10;
            }
            else {
                boardCard = 10;
                matchNum = 13;
            }
        }
        public int BoardCard
        {
            get
            {
                return boardCard;
            }
        }

        public void showGameRule() {
            if (gameNum == 10)
            {
                Console.WriteLine("Please choose up to 4 cards, and the sum is 10. If you have 4 J or Q or K in the hand of Sunlight, you can also choose.");
               
            }
            else if (gameNum == 11)
            {
                Console.WriteLine("Please choose up to 3 cards, and the sum is 11. If you have  J and Q and K in the hand of Sunlight, you can also choose.");
               
            }
            else {
                Console.WriteLine("Please choose up to 4 cards, and the sum is 13. If you have 4 J or Q or K in the hand of Sunlight, you can also choose.");
            }
            Console.WriteLine("After entering the serial number, press Enter. If it is correct, the system will automatically replace the hand card.");
        }
        /**
         * parameter @ Card a and Card b
         * todo@ return error msg
         */
        public bool matchGame11RuleNumber(params Card[] dyncParams)
        {
            if (dyncParams == null || dyncParams.Length == 0)
            {
                return false;
            }
            else if (dyncParams.Length > cardQuinity)
            {
                return false;
            }
            else {
                // Calculate the value of the card

                int value = 0;
                foreach (Card card in dyncParams) {
                    Console.WriteLine(" --------------------------------------------------   " );
                    Console.WriteLine(card.Rank + "    " + card.Suit);
                    value += (int)System.Enum.Parse(typeof(Rank), card.Rank) + 1;
                }
                if (value == matchNum || value == 36) { 
                    return true; 
                } else {
                    return false;
                }
                
            }
        }
        //todo
        public bool matchGame10RuleNumber(params Card[] dyncParams)
        {
            if (dyncParams == null || dyncParams.Length == 0)
            {
                return false;
            }
            else if (dyncParams.Length > cardQuinity)
            {
                return false;
            }
            else
            {
                // Calculate the value of the card

                int value = 0;

                foreach (Card card in dyncParams)
                {
                    Console.WriteLine(" --------------------------------------------------   ");
                    Console.WriteLine(card.Rank + "    " + card.Suit);
                    value += (int)System.Enum.Parse(typeof(Rank), card.Rank) + 1;
                }
                if (value == matchNum || value/dyncParams.Length == 11 || value / dyncParams.Length == 12 || value / dyncParams.Length == 13)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        //todo
        public bool matchGame13RuleNumber(params Card[] dyncParams)
        {
            if (dyncParams == null || dyncParams.Length == 0)
            {
                return false;
            }
            else if (dyncParams.Length > cardQuinity)
            {
                return false;
            }
            else
            {
                // Calculate the value of the card

                int value = 0;
                foreach (Card card in dyncParams)
                {
                    value += (int)System.Enum.Parse(typeof(Rank), card.Rank) + 1;
                }
                if (value == matchNum || value % dyncParams.Length== 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

    }
}
