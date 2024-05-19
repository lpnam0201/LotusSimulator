﻿using LotusSimulator.Client.Layout;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LotusSimulator.Client.Hand
{
    public class HandZone : IPlayerIdentity
    {
        private const int DistanceBetweenCards = 10;

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ConnectionId { get; set; }

        public IList<Card.CardZone> Cards { get; set; } = new List<Card.CardZone>();

        public void Draw(GameTime gameTime)
        {
            var greenBar = new Texture2D(GlobalInstances.GraphicsDevice, 1, 1);
            greenBar.SetData(new[] { Color.Green });

            GlobalInstances.SpriteBatch.Draw(greenBar, new Rectangle(X, Y, Width, Height), Color.White);

            var numberOfCards = Cards.Count;
            var numberOfGaps = Cards.Count - 1;
            var totalWidth = numberOfCards * Card.CardZone.CardWidth + numberOfGaps * DistanceBetweenCards;

            var firstCardX = X + (Width - totalWidth) / 2;

            for (var i = 0; i < Cards.Count; i++)
            {
                var card = Cards[i];
                card.X = firstCardX + i * Card.CardZone.CardWidth + i * DistanceBetweenCards;
                card.Y = Y;
                card.Draw(gameTime);
            }
        }

        public void Update(GameTime gameTime)
        {
            Cards.Clear();

            var handDto = GlobalInstances.GameDisplayModel.GameState.GetHand(ConnectionId);
            foreach (var cardDto in handDto.Cards)
            {
                var card = new Card.CardZone();
                card.Id = cardDto.Id;
                card.OracleId = cardDto.OracleId;
                card.IsRevealed = cardDto.IsRevealed;
                Cards.Add(card);
            }
        }
    }
}
