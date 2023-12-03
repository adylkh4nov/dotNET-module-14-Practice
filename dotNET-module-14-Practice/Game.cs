using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_module_14_Practice
{
    public class Game
    {
        public List<Player> players;
        public List<Karta> deck;

        public Game(int playersCount)
        {
            players = new List<Player>();
            for (int i = 0; i < playersCount; i++)
            {
                players.Add(new Player());
            }

            deck = new List<Karta>();
            GenerateDeck();
            ShuffleDeck();
            DistributeCards();
        }

        private void GenerateDeck()
        {
            string[] mastList = { "Пики", "Черви", "Буби", "Крести" };
            string[] nominalList = { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };

            foreach (var mast in mastList)
            {
                foreach (var nominal in nominalList)
                {
                    deck.Add(new Karta(mast, nominal));
                }
            }
        }

        private void ShuffleDeck()
        {
            Random rnd = new Random();
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                Karta value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }
        

        private void DistributeCards()
        {
            int cardsPerPlayer = deck.Count / players.Count;
            int cardIndex = 0;

            foreach (var player in players)
            {
                for (int i = 0; i < cardsPerPlayer; i++)
                {
                    player.AddCard(deck[cardIndex]);
                    cardIndex++;
                }
            }
        }
    }
}
