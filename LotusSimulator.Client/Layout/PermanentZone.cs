using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LotusSimulator.Client.Layout
{
    public class PermanentZone : IPlayerIdentity
    {
        public const int PermanentWidth = 70;
        public const int PermanentHeight = 70;

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; } = 70;
        public int Height { get; set; } = 70;
        public int Slot { get; set; }

        public void Draw(GameTime gameTime)
        {
            var greenBar = new Texture2D(GlobalInstances.GraphicsDevice, 1, 1);
            greenBar.SetData(new[] { Color.Pink });
            GlobalInstances.SpriteBatch.Draw(greenBar, new Rectangle(X, Y, Width, Height), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}
