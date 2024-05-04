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
    public class LifeOrb
    {
        private Texture2D _lifeOrb = HostedService.ContentManager.Load<Texture2D>("life_total");
        private SpriteFont _lifeFont = HostedService.ContentManager.Load<SpriteFont>("LifeTotal");

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public void Draw()
        {
            var sourceRectangle = new Rectangle(0, 0, _lifeOrb.Width, _lifeOrb.Height);
            var destinationRectangle = new Rectangle(X, Y, Width, Height);
            HostedService.SpriteBatch.Draw(_lifeOrb, destinationRectangle, sourceRectangle, Color.White);

            //HostedService.SpriteBatch.DrawString(_lifeFont, "20", new Vector2(X, Y), Color.White);
        }
    }
}
