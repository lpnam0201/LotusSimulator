using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;

namespace LotusSimulator.Client.Layout
{
    public class LayoutManager
    {
        private TwoPlayersLayout _twoPlayersLayout;
        private FourPlayersLayout _fourPlayersLayout;
        private bool isDrawn = false;

        public LayoutManager()
        {
            _twoPlayersLayout = new TwoPlayersLayout();
            _fourPlayersLayout = new FourPlayersLayout();
        }

        public void Draw(GameTime gameTime)
        {
            _twoPlayersLayout.Draw(gameTime);

            if (!isDone)
            {
                isDone = true;
                var panel = new Panel();
                panel.Top = 0;
                panel.Left = 0;

                var button = new Button();
                button.Width = 100;
                button.Height = 30;
                button.Click += Button_Click;

                var label = new Label();
                label.Text = "ABC";
                button.Content = label;

                panel.Widgets.Add(button);
                GlobalInstances.Desktop.Root = panel;
            }
        }

        private bool isDone;

        private void Button_Click(object sender, System.EventArgs e)
        {
            GlobalInstances.GameStateService.ConnectToGameAsync().GetAwaiter().GetResult();
        }

        public void Update(GameTime gameTime)
        {
            _twoPlayersLayout.Update(gameTime);
        }
    }
}
