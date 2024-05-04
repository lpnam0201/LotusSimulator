using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Deck
{
    public class Deck
    {
        public IList<Card.Card> Cards = new List<Card.Card>();

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Deck()
        {
            Cards = new List<Card.Card>();
            for (int i = 0; i < 13; i++)
            {
                Cards.Add(new Card.Card());
            }
        }

        public void Draw(GameTime gameTime)
        {

            for (int i = 0; i < Cards.Count; i++)
            {
                var card = Cards[i];
                card.X = X - i;
                card.Y = Y - i;
                card.Draw(gameTime);
            }

        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}
