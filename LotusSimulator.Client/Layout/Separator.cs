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
    public class Separator
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public void Draw(GameTime gameTime)
        {
            var whiteBar = new Texture2D(GlobalInstances.GraphicsDevice, 1, 1);
            whiteBar.SetData(new[] { Color.White });

            GlobalInstances.SpriteBatch.Draw(whiteBar, new Rectangle(X, Y, Width, Height), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}
