using System;
using System.Collections.Generic;
using System.Text;

namespace csc350h
{
    public class GameBaord
    {
        List<Card> cardList;
        Deck gameDeck;
        String userName;
        int wins;
        int games;
        int boardSize;
        //constructer
        public GameBaord(string name,int size) {
            userName = name;
            wins = 0;
            games = 1;
            boardSize = size;
        }
        
        /**
         * game star and Licensing base on which game the player choose , game
         * */
        public void licensingCard() {
            //根据游戏规则设计的大小发牌
            for (int i =0; i< boardSize; i++) {
                cardList.Add(gameDeck.TakeTopCard());
            }
        }

        /**
         * display cardslist in card board
         */
        public void displayCardList() {
            for (int i = 0; i < cardList.Count; i++)
            {
                Console.WriteLine(i + 1 + ":" + "[" + cardList[i].Rank + "," + cardList[i].Suit + "] ");   
            }
            Console.WriteLine();
           
            Console.WriteLine("Please enter the serial number of your selected card, please use ' - ' to separate");
            
            
        }

        /**
         *玩家选择卡牌
         *@pparameter int[] selectIndex;
         *@return Card[] selected;
         */
        public Card[] playerSelectCard(int[] selectIndexs) {
            List<Card> selected = new List<Card>();
            foreach (int a in selectIndexs) {
                if (a > cardList.Count||a<0)
                {
                    //如果用输入的下标大于台面卡片集合大小直接返回null
                    return null;
                }
                else {
                    selected.Add(cardList[a]);
                }
            }
            //把集合变成数组
            return selected.ToArray();
        }

        /**
         * 选完卡后根据验证方法返回真 ture 和false 进行是重新选择还是删除所选卡片然后再增加对应数量的卡片
         * @pparameter bool  check;
         * @pparameter int[] selectIndexs
         */
        public void deleteOrAddCard(bool check, int[] selectIndexs) {
            if (check)
            {
                //更新覆盖用户所选卡的位置
                foreach (int a in selectIndexs)
                {
                    cardList[a] = gameDeck.TakeTopCard();
                }
                displayCardList();
                displayMSG();
            }
            else {
                //show some msg
                Console.WriteLine("wrong pick ,select the card again!!!!");
            }
        }
        /**
         * display how many card in deck
         */
        public void displayMSG(){
            Console.WriteLine();
            
            //Console.WriteLine("Enter RP to replace the card!!");
            Console.WriteLine("Enter RS to restart the game!!");
            Console.WriteLine("Enter EXIT to GO BACK the game MUNE!!");
            Console.WriteLine(gameDeck.getCardsRemainNum() +" undealt cards remains" );
            Console.WriteLine(" You've "+wins+" out of " + games+ " games");
        }
        /**
         * check win for game type 11
         */
        public bool checkWinSGame()
        {
            if (gameDeck.Empty) {
                wins++;
                return true;
            }else return false;
           
        }
        /**
        * RESTART
        */
        public void START()
        {
            cardList = new List<Card>();
            gameDeck = new Deck();
            gameDeck.shuffle();
            licensingCard();
            displayCardList();
            displayMSG();
           
        }
        /**
        * RESTART
        */
        public void RESTART()
        {
            cardList = new List<Card>();
            gameDeck = new Deck();
            gameDeck.shuffle();
            licensingCard();
            displayCardList();
            displayMSG();
            games++;
        }

       static GameRule chooseGameAndShowMsg() {
           
            Console.WriteLine(" Please select a game. Enter 1 for GAME10, 2 for GAME11, and 3 for GAME13");
            int gameType = Convert.ToInt16(Console.ReadLine());
            GameRule gameRule = null; ;
            while (gameRule == null)
            {
                if (gameType == 1)
                {
                    gameRule = new GameRule(10, 13);
                }
                else if (gameType == 2)
                {
                    gameRule = new GameRule(11, 3);
                }
                else if (gameType == 3)
                {
                    gameRule = new GameRule(13, 9);
                }
                else
                {
                    Console.WriteLine(" Please select a game. Enter 1 for GAME10, 2 for GAME11, and 3 for GAME13");
                    gameType = Console.Read();
                }
            }
            return gameRule;
        }


        static void  Main(string[] args)
        {
            //显示菜单
            Console.WriteLine("Please enter your name");
            string name = Console.ReadLine();
            //用户选择游戏规则
            GameRule gameRule = chooseGameAndShowMsg();
            //开始发牌
            GameBaord game = new GameBaord(name, gameRule.BoardCard);
            game.START();
            while (!game.checkWinSGame()) {
                //选择卡牌-》用户输入选择的数组下标后按回车进行下一步直接判断
                gameRule.showGameRule();
                string palyerEnterCards = Console.ReadLine();
               if (palyerEnterCards != "")
                {
                    if (palyerEnterCards == "RS")//restart the game
                    {
                        game.RESTART();
                    } else if (palyerEnterCards == "EXIT") {
                        Environment.Exit(0);
                    }
                    else {
                        //把用户输入的下标字符串分割成int[]
                        string[] array = palyerEnterCards.Split('-');
                        if (array.Length > 0)
                        {
                            int[] selectIndexs = new int[array.Length];
                            for (int i = 0; i < array.Length; i++)
                            {
                                selectIndexs[i] = Convert.ToInt16(array[i]) - 1;
                            }
                            //开始计算用户选择的卡片是否符合规则
                            Card[] playerSelected = game.playerSelectCard(selectIndexs);
                            bool check = false;
                            if (gameRule.gameNum == 10)
                            {
                                check = gameRule.matchGame10RuleNumber(playerSelected);
                            }
                            else if (gameRule.gameNum == 11)
                            {
                                check = gameRule.matchGame11RuleNumber(playerSelected);
                            }
                            else if (gameRule.gameNum == 13)
                            {
                                check = gameRule.matchGame13RuleNumber(playerSelected);
                            }
                            //根据判断从新选择还是删除卡牌再新增新卡牌 deleteOrAddCard()
                            game.deleteOrAddCard(check, selectIndexs);
                        }
                    }
                }
            }
            //赢了以后干嘛？？
            


            //
            //从新打印cardlist

        }

    }

    
}
