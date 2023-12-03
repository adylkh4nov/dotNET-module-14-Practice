using System;
using System.Collections.Generic;

namespace dotNET_module_14_Practice
{
    public class Program
    {

        static void Main(string[] args)
        {
            string kozir = "Крести"; 

            
            Game game = new Game(2);

       
            while (!HasGameEnded(game))
            {
                PlayRound(game, ref kozir);
            }

            
            int winnerIndex = DetermineWinner(game);
            Console.WriteLine($"Победил игрок {winnerIndex + 1}!");
        }

        static void PlayRound(Game game, ref string kozir)
        {
            List<Karta> roundCards = new List<Karta>();

            // Каждый игрок кладет по одной карте
            foreach (var player in game.players)
            {
                if (player.Cards.Count > 0)
                {
                    Karta card = player.Cards[0];
                    roundCards.Add(card);
                    player.Cards.RemoveAt(0);

                    Console.WriteLine($"Игрок {game.players.IndexOf(player) + 1} кладет карту: {card.Nominal} {card.Mast}");
                }
            }

          
            int maxNominal = 0;
            int winningCardIndex = -1;

            for (int i = 0; i < roundCards.Count; i++)
            {
                int nominalValue = GetNominalValue(roundCards[i], kozir);
                if (nominalValue > maxNominal)
                {
                    maxNominal = nominalValue;
                    winningCardIndex = i;
                }
            }

            
            if (winningCardIndex != -1)
            {
                Karta winningCard = roundCards[winningCardIndex];
                Console.WriteLine($"Выигрывает карта: {winningCard.Nominal} {winningCard.Mast}");
            }

           
            Random rnd = new Random();
            int randomIndex = rnd.Next(game.deck.Count);
            kozir = game.deck[randomIndex].Mast;
        }


        static int GetNominalValue(Karta card, string kozir)
        {
            string[] nominalOrder = { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };
            for (int i = 0; i < nominalOrder.Length; i++)
            {
                if (card.Nominal == nominalOrder[i])
                {
                    if (card.Mast == kozir)
                    {
                        return i + 10; 
                    }
                    else
                    {
                        return i + 1; 
                    }
                }
            }
            return 0; 
        }

        static bool HasGameEnded(Game game)
        {
            foreach (var player in game.players)
            {
                if (player.Cards.Count == 0)
                {
                    return true; 
                }
            }
            return false;
        }

        static int DetermineWinner(Game game)
        {
            int winnerIndex = -1;
            int minCardsCount = int.MaxValue;

            for (int i = 0; i < game.players.Count; i++)
            {
                if (game.players[i].Cards.Count < minCardsCount)
                {
                    minCardsCount = game.players[i].Cards.Count;
                    winnerIndex = i;
                }
            }

            return winnerIndex;
        }
    }
}