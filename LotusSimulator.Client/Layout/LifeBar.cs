using LotusSimulator.Client.Global;
using Microsoft.Xna.Framework;

namespace LotusSimulator.Client.Layout
{
    public class LifeBar : IPlayerIdentity
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; } = 40;
        public int Height { get; set; } = 100;
        public string ConnectionId { get; set; }

        public void Draw(GameTime gameTime)
        {
            var lifeBarTexture = ContentTextures.LifeBar;
            
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
