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
            if (!isDrawn)
            {
                isDrawn = true;
            }
            _twoPlayersLayout.Draw(gameTime);

            if (!isshow)
            {
                isshow = true;
                var dialog = Dialog.CreateMessageBox("ABC", "xyz");
                dialog.ZIndex = 100;
                dialog.ShowModal(GlobalInstances.Desktop, new Point(0, 0));
            }
        }

        private bool isshow = false;

        public void Update(GameTime gameTime)
        {
            _twoPlayersLayout.Update(gameTime);
        }
    }
}
