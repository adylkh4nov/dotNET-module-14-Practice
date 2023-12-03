using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_module_14_Practice
{
    public class Player
    {
        public List<Karta> Cards { get; set; }

        public Player()
        {
            Cards = new List<Karta>();
        }

        public void AddCard(Karta card)
        {
            Cards.Add(card);
        }

        public void DisplayCards()
        {
            foreach (var card in Cards)
            {
                Console.WriteLine($"{card.Nominal} {card.Mast}");
            }
        }
    }

}
