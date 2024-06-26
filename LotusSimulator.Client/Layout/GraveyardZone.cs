﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Layout
{
    public class GraveyardZone : IPlayerIdentity
    {
        public IList<Card.CardZone> Cards = new List<Card.CardZone>();

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ConnectionId { get; set; }

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

            var graveyard = GlobalInstances.GameDisplayModel.GetGraveyard(ConnectionId);
            foreach (var gameObject in graveyard.GameObjects)
            {
                var card = new Card.CardZone();
                card.Id = gameObject.Id;
                card.OracleId = gameObject.OracleId;
                card.IsRevealed = gameObject.IsRevealed;
                Cards.Add(card);
            }
        }
    }
}
