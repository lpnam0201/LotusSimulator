using LotusSimulator.Client.Global;
using LotusSimulator.Contract.MessageIn;
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
                _button.Click += PassPriority_Click;

                var label = new Label();
                label.Text = "Pass priority";
                _button.Content = label;
                GlobalInstances.Desktop.Widgets.Add(_button);
            }
        }

        private void PassPriority_Click(object sender, EventArgs e)
        {
            GlobalInstances.GameStateService.PassPriority(new PassPriorityDto
            {
                GameId = GlobalInstances.GamePreparationState.GameId
            }).GetAwaiter().GetResult();
        }

        public void Update(GameTime gameTime)
        {
            if (GlobalInstances.GameDisplayModel.PriorityHolder == GlobalInstances.YourConnectionId)
            {
                _button.Visible = true;
            }
            else
            {
                _button.Visible = false;
            }
        }
    }
}
