using LotusSimulator.Client.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Layout
{
    public class LayoutManager
    {
        private TwoPlayersLayout _twoPlayersLayout;
        private FourPlayersLayout _fourPlayersLayout;

        public LayoutManager()
        {
            _twoPlayersLayout = new TwoPlayersLayout();
            _fourPlayersLayout = new FourPlayersLayout();
        }

        public void Draw(GameTime gameTime)
        {
            _fourPlayersLayout.Draw(gameTime);
            //_twoPlayersLayout.Draw(gameTime);
        }

        public void Update(GameTime gameTime)
        {
            _twoPlayersLayout.Update(gameTime);
        }
    }
}
