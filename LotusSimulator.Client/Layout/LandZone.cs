﻿using LotusSimulator.Client.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LotusSimulator.Client.Layout
{
    public class LandZone : IPlayerIdentity
    {
        private const int NavigationArrowWidth = 20;
        private const int NumberOfPermanentZones = 7;

        public IList<PermanentZone> Permanents = new List<PermanentZone>();

        public LandZone()
        {
            for (int i = 0; i < NumberOfPermanentZones; i++)
            {
                Permanents.Add(new PermanentZone()
                {
                    DisplayZone = DisplayZone.Land,
                    ConnectionId = ConnectionId,
                    Index = i
                });
            }
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ConnectionId { get; set; }

        public void Draw(GameTime gameTime)
        {
            var greenBar = new Texture2D(GlobalInstances.GraphicsDevice, 1, 1);
            greenBar.SetData(new[] { Color.Blue });
            GlobalInstances.SpriteBatch.Draw(greenBar, new Rectangle(X, Y, Width, Height), Color.White);

            var numberOfGaps = NumberOfPermanentZones - 1;
            var gapWidth = (Width - NavigationArrowWidth * 2 - NumberOfPermanentZones * PermanentZone.PermanentWidth) / numberOfGaps;
            var firstLandX = X + NavigationArrowWidth;

            for (int i = 0; i < Permanents.Count; i++)
            {
                var permanentZone = Permanents[i];
                permanentZone.X = firstLandX + PermanentZone.PermanentWidth * i + gapWidth * i;
                permanentZone.Y = Y;

                permanentZone.Draw(gameTime);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var permanent in Permanents)
            {
                permanent.ConnectionId = ConnectionId;
                permanent.Update(gameTime);
            }
        }
    }
}
