using LotusSimulator.Client.Global;
using Microsoft.Xna.Framework;
using Myra.Graphics2D;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Layout
{
    public class Priority
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Slot { get; set; }

        private bool _isDraw;
        private bool _shouldDraw;
        private Button _button = new Button();

        public void Draw(GameTime gameTime)
        {
            if (!_shouldDraw)
            {
                if (_button.Desktop != null)
                {
                    _button.RemoveFromDesktop();
                }
                return;
            }

            if (!_isDraw && _shouldDraw)
            {
                _isDraw = true;
                
                _button.Top = X;
                _button.Left = Y;
                _button.Width = 100;
                _button.Height = 30;

                var label = new Label();
                label.Text = "Pass priority";
                _button.Content = label;
                GlobalInstances.Desktop.Widgets.Add(_button);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (GlobalInstances.GameState.PriorityHolder == Slot)
            {
                _shouldDraw = true;
            }
            else
            {
                _shouldDraw = false;
            }
        }
    }
}
