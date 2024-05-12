using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.GUIComponents.Screens
{
    public class StartScreen : Screen
    {
        private bool _isDrawn;

        public override void Draw(GameTime gameTime)
        {
            if (!_isDrawn)
            {
                var button = BuildStartButton();

                var grid = new Grid();
                grid.Left = 0;
                grid.Top = 0;
                grid.RowsProportions.Add(new Proportion());

                Grid.SetRow(button, 0);
                Grid.SetColumn(button, 0);
                grid.Widgets.Add(button); 
                GlobalInstances.Desktop.Root = grid;

                _isDrawn = true;
            }
        }

        private Button BuildStartButton()
        {
            var label = new Label();
            label.Text = "Start";

            var button = new Button();
            button.Width = 100;
            button.Height = 50;
            button.Content = label;
            button.Click += PlayButton_Click;

            return button;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            GlobalInstances.ScreenManager.SetScreenKind(ScreenKind.GamePreparation);
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
