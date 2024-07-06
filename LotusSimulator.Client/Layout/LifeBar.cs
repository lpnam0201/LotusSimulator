using LotusSimulator.Client.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LotusSimulator.Client.Layout
{
    public class LifeBar : IPlayerIdentity
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; } = 100;
        public int Height { get; set; } = 40;
        public string ConnectionId { get; set; }
        private int _lifeTotal;

        public void Draw(GameTime gameTime)
        {
            DrawLifeContainer(gameTime);
            DrawLifeTotalText(gameTime);
        }

        private void DrawLifeTotalText(GameTime gameTime)
        {
            var x = X + Width / 2;
            var spriteFont = ContentTextures.Font;
            GlobalInstances.SpriteBatch.DrawString(spriteFont, _lifeTotal.ToString(), new Vector2(x, Y), Color.White);
        }

        private void DrawLifeContainer(GameTime gameTime)
        {
            var lifeBarTexture = ContentTextures.LifeBar;
            GlobalInstances.SpriteBatch.Draw(lifeBarTexture, new Rectangle(X, Y, Width, Height), Color.White);
        }
        public void Update(GameTime gameTime)
        {
            _lifeTotal = GlobalInstances.GameDisplayModel.GetPlayer(ConnectionId).LifeTotal;
        }
    }
}
