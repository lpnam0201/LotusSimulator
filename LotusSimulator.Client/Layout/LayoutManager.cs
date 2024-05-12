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
        }

        public void Update(GameTime gameTime)
        {
            _twoPlayersLayout.Update(gameTime);
        }
    }
}
