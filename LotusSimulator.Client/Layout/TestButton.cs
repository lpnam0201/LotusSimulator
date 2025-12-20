using LotusSimulator.Contract.MessageIn;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Layout
{
    public class TestButton
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private bool _isDraw;
        private Button _button = new Button();

        public void Draw(GameTime gameTime)
        {
            if (!_isDraw)
            {
                _isDraw = true;

                _button.Left = X;
                _button.Top = Y;
                _button.Width = 100;
                _button.Height = 30;
                _button.Click += TestButton_Click;

                var label = new Label();
                label.Text = "Input";
                _button.Content = label;
                GlobalInstances.Desktop.Widgets.Add(_button);
            }
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            GlobalInstances.GameStateService.TestButton(new TestButtonDataDto
            {
                GameId = GlobalInstances.GamePreparationState.GameId,
                Guid = GlobalInstances.GamePreparationState.Player.TestButtonGuid,
                Age = 3,
                Name = "blah"
            }).GetAwaiter().GetResult();
        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}
