using LotusSimulator.Client.Global;
using LotusSimulator.Client.GUIComponents.ContextMenu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Myra.Graphics2D.UI;
using System;

namespace LotusSimulator.Client.Card
{
    public class CardZone : ICardIdentity
    {
        public const int CardWidth = 50;
        public const int CardHeight = 70;

        public bool IsRevealed { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; } = CardWidth;
        public int Height { get; set; } = CardHeight;
        public string Id { get; set; }
        public string OracleId { get; set; }

        public void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            if (mouseState.RightButton == ButtonState.Pressed
                && IsInHitBox(mouseState))
            {
                if (GlobalInstances.Desktop.ContextMenu == null
                    && GlobalInstances.Desktop.TouchPosition != null)
                {
                    var gameObject = GlobalInstances.PlayabilityUpdateService.GetGameObject(Id);
                    if (gameObject.Playabilities.Count > 0)
                    {
                        var contextMenu = new PlayabilityContextMenu(gameObject.Playabilities);
                        contextMenu.Show();
                    }
                }
            };
        }

        private bool IsInHitBox(MouseState mouseState)
        {
            if (mouseState.X >= X && mouseState.X <= X + Width
                && mouseState.Y > Y && mouseState.Y <= Y + Height)
            {
                return true;
            }

            return false;
        }

        public void Draw(GameTime gameTime)
        {
            Texture2D texture;
            if (OracleId == null)
            {
                texture = ContentTextures.MTGBack;
            }
            else
            {
                texture = GlobalInstances.LookupCardImageService.LookupCardImage(OracleId);
            }
            GlobalInstances.SpriteBatch.Draw(texture, new Rectangle(X, Y, Width, Height), Color.White);
        }
    }
}
