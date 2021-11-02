# Game11Git
csc350h project1
Class:
1)GameRule
a)Element:
public int gameNum; // Game rules target numbers, 10, 11, 13
public int matchNum;// the cum of the selected Card value
public int boardCard; // how many card in the table
public int cardQuinity;//how many card the player can select

b)founction
void showGameRule();
show message about the game;

bool matchGame11RuleNumber(params Card[] dyncParams);
 
bool matchGame10RuleNumber(params Card[] dyncParams)；
 
bool matchGame13RuleNumber(params Card[] dyncParams)；
	According to the rules of the game, the input parameter is an array of cards selected by the user, and return whether the selection is correc.
 

2)GameBaord
a)Element:
List<Card> cardList;
Deck gameDeck;
String userName;
int wins;
int games;
int boardSize;

b)founction

(1)Game star and Licensing base on which game the player choose game.
void licensingCard();
 
(2)Display cardslist in card board.
void displayCardList()
 
(3)Player chooses a card.
@pparameter int[] selectIndex;
@return Card[] selected;

Card[] playerSelectCard(int[] selectIndexs)
 
(4)After selecting the card, return true and false according to the verification method, and select whether to reselect or delete the selected card and then add the corresponding number of cards.
@pparameter bool  check;
@pparameter int[] selectIndexs
void deleteOrAddCard(bool check, int[] selectIndexs)
 
(5):START();
      RESTART();
	 
(6):Create game rule objects according to the user's choice
    chooseGameAndShowMsg()；

 


Game logic：
 

1: Display menu
2：Users choose game rules
3: Select the card-"The user enters the selected array subscript and press Enter to proceed to the next step to directly judge
4: Split the subscript string entered by the user into int[]
5: After the user selects the card, it starts to calculate whether the card selected by the user complies with the rules and the system will automatically replace the card
6: According to the judgment, whether to select a new card or delete a card and add a new card
7: Check whether you have won
8: Record the number of victories and defeats

