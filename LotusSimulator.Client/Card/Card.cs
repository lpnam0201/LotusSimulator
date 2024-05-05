using LotusSimulator.Client.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Myra.Graphics2D.UI;
using System;

namespace LotusSimulator.Client.Card
{
    public class Card
    {
        public const int CardWidth = 50;
        public const int CardHeight = 70;

        public bool IsTapped { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; } = CardWidth;
        public int Height { get; set; } = CardHeight;

        private float rotation = 0;

        public void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            if (mouseState.RightButton == ButtonState.Pressed
                && IsInHitBox(mouseState))
            {
                if (GlobalInstances.Desktop.ContextMenu == null
                    && GlobalInstances.Desktop.TouchPosition != null)
                {
                    var container = new VerticalStackPanel
                    {
                        Spacing = 4
                    };

                    var menuItem1 = new MenuItem();
                    menuItem1.Text = "Start New Game";
                    menuItem1.Selected += (s, a) =>
                    {
                        Console.WriteLine("CLICKED");
                    };

                    var menuItem2 = new MenuItem();
                    menuItem2.Text = "Options";

                    var menuItem3 = new MenuItem();
                    menuItem3.Text = "Quit";

                    var verticalMenu = new VerticalMenu();

                    verticalMenu.Items.Add(menuItem1);
                    verticalMenu.Items.Add(menuItem2);
                    verticalMenu.Items.Add(menuItem3);

                    container.Widgets.Add(verticalMenu);

                    GlobalInstances.Desktop.ShowContextMenu(container, GlobalInstances.Desktop.TouchPosition.Value);
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
            GlobalInstances.SpriteBatch.Draw(ContentTextures.MTGBack, new Rectangle(X, Y, Width, Height), Color.White);
        }
    }
}
