using LotusSimulator.Client.Global;
using LotusSimulator.Client.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace LotusSimulator.Client.Layout
{
    public class PermanentZone : IPlayerIdentity
    {
        public const int PermanentWidth = 50;
        public const int PermanentHeight = 70;


        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; } = 70;
        public int Height { get; set; } = 70;
        public string OracleId { get; set; }
        public string ConnectionId { get; set; }
        public DisplayZone DisplayZone { get; set; }
        public int Page { get; set; }
        public int Index { get; set; }

        public void Draw(GameTime gameTime)
        {
            var greenBar = new Texture2D(GlobalInstances.GraphicsDevice, 1, 1);
            greenBar.SetData(new[] { Color.Pink });
            GlobalInstances.SpriteBatch.Draw(greenBar, new Rectangle(X, Y, Width, Height), Color.White);

            DrawCard(gameTime);
        }

        private void DrawCard(GameTime gameTime)
        {
            Texture2D texture;
            if (OracleId != null)
            {
                texture = GlobalInstances.LookupCardImageService.LookupCardImage(OracleId);
                var x = X + (Width - PermanentWidth) / 2;
                var y = Y;
                GlobalInstances.SpriteBatch.Draw(texture, new Rectangle(x, y, PermanentWidth, PermanentHeight), Color.White);
            }
        }

        public void Update(GameTime gameTime)
        {
            var player = GlobalInstances.GameDisplayModel.Players.FirstOrDefault(x => x.Id == ConnectionId);
            var gameObject = player?.Battlefield?.GetGameObject(DisplayZone, Page, Index);
            if (gameObject != null)
            {
                OracleId = gameObject.OracleId;
            }
            else
            {
                OracleId = null;
            }
        }
    }
}
