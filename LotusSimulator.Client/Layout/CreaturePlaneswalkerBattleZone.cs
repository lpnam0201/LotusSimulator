using LotusSimulator.Client.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LotusSimulator.Client.Layout
{
    public class CreaturePlaneswalkerBattleZone : IPlayerIdentity
    {
        private const int NavigationArrowWidth = 20;
        private const int NumberOfPermanentZones = 14;
        private const int NumberOfPermanentZonesPerRow = 7;

        private const int RowGap = 10;


        public IList<PermanentZone> Permanents = new List<PermanentZone>();

        public CreaturePlaneswalkerBattleZone()
        {
            for (int i = 0; i < NumberOfPermanentZones; i++)
            {
                Permanents.Add(new PermanentZone()
                {
                    DisplayZone = DisplayZone.CreaturePlaneswalkerBattle,
                    ConnectionId = ConnectionId,
                    Index = PermanentBeginIndex + i
                });
            }
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ConnectionId { get; set; }
        public int PermanentBeginIndex { get; set; }

        public void Draw(GameTime gameTime)
        {
            var greenBar = new Texture2D(GlobalInstances.GraphicsDevice, 1, 1);
            greenBar.SetData(new[] { Color.Orange });
            GlobalInstances.SpriteBatch.Draw(greenBar, new Rectangle(X, Y, Width, Height), Color.White);

            DrawRow(gameTime, Y, 0);
            DrawRow(gameTime, Y + PermanentZone.PermanentHeight + RowGap, 7);
        }

        private void DrawRow(GameTime gameTime, int y, int indexBegin)
        {
            var numberOfGaps = NumberOfPermanentZonesPerRow - 1;
            var gapWidth = (Width - NavigationArrowWidth * 2 - NumberOfPermanentZonesPerRow * PermanentZone.PermanentWidth) / numberOfGaps;
            var firstLandX = X + NavigationArrowWidth;

            for (int i = 0; i < 7; i++)
            {
                var permanentZone = Permanents[i + indexBegin];
                permanentZone.X = firstLandX + PermanentZone.PermanentWidth * i + gapWidth * i;
                permanentZone.Y = y;

                permanentZone.Draw(gameTime);
            }
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
