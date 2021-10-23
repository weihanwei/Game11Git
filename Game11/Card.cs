using System;
using System.Collections.Generic;
using System.Text;

namespace csc350h
{
    public class Card
    {
        string rank;
        string suit;
        bool faceUp;

        public Card(string rank, string suit) {
            this.rank = rank;
            this.suit = suit;
            faceUp = false;
        }
         
        public string Rank {
            get {
                return rank;
            }
        }

        public string Suit {
            get {
                return suit;
            }
        }

        public bool FaceUp {
            get {
                return faceUp;
            }
        }
        public void FlipOver() {
            faceUp = !faceUp;
        }

    }
}
