﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Layout
{
    public class Graveyard : IPlayerIdentity
    {
        public IList<Card.Card> Cards = new List<Card.Card>();

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Slot { get; set; }

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
            Cards.Clear();

            var libraryDto = GlobalInstances.GameState.GetGraveyard(Slot);
            foreach (var cardDto in libraryDto.Cards)
            {
                var card = new Card.Card();
                card.Id = cardDto.Id;
                card.OracleId = cardDto.OracleId;
                card.IsRevealed = cardDto.IsRevealed;
                Cards.Add(card);
            }
        }
    }
}
