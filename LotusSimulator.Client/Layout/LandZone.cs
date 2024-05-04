using LotusSimulator.Client.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Layout
{
    public class LandZone
    {
        private const int NavigationArrowWidth = 20;
        private const int NumberOfPermanentZones = 7;

        public IList<PermanentZone> Permanents = new List<PermanentZone>();

        public LandZone()
        {
            for (int i = 0; i < NumberOfPermanentZones; i++)
            {
                Permanents.Add(new PermanentZone());
            }
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public void Draw(GameTime gameTime)
        {
            var greenBar = new Texture2D(HostedService.GraphicsDevice, 1, 1);
            greenBar.SetData(new[] { Color.Blue });
            HostedService.SpriteBatch.Draw(greenBar, new Rectangle(X, Y, Width, Height), Color.White);

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
            
        }
    }
}
