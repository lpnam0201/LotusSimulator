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
    public class TwoPlayersLayout
    {
        private const int PlayerAreaWidth = 900;
        private const int PlayerAreaHeight = 450;

        private const int SeparatorHeight = 40;

        private const int BottomPlayerDistFromTop = PlayerAreaHeight + SeparatorHeight;

        private TopPlayerArea _topPlayerArea;
        private BottomPlayerArea _bottomPlayerArea;

        public TwoPlayersLayout()
        {
            _topPlayerArea = new TopPlayerArea();
            _bottomPlayerArea = new BottomPlayerArea();
        }

        public void Draw(GameTime gameTime)
        {
            DrawTopPlayerArea(gameTime);
            DrawBottomPlayerArea(gameTime);

            DrawSeparator(gameTime);
        }

        public void Update(GameTime gameTime)
        {
            _topPlayerArea.Update(gameTime);
            _bottomPlayerArea.Update(gameTime);
        }

        private void DrawTopPlayerArea(GameTime gameTime)
        {
            var displayWidth = GlobalInstances.GraphicsDevice.Adapter.CurrentDisplayMode.Width;

            _topPlayerArea.X = displayWidth / 2 - PlayerAreaWidth / 2;
            _topPlayerArea.Y = 0;

            _topPlayerArea.Width = PlayerAreaWidth;
            _topPlayerArea.Height = PlayerAreaHeight;

            _topPlayerArea.Draw(gameTime);
        }

        private void DrawBottomPlayerArea(GameTime gameTime)
        {
            var displayWidth = GlobalInstances.GraphicsDevice.Adapter.CurrentDisplayMode.Width;

            _bottomPlayerArea.X = displayWidth / 2 - PlayerAreaWidth / 2;
            _bottomPlayerArea.Y = BottomPlayerDistFromTop;

            _bottomPlayerArea.Width = PlayerAreaWidth;
            _bottomPlayerArea.Height = PlayerAreaHeight;

            _bottomPlayerArea.Draw(gameTime);
        }

        private void DrawSeparator(GameTime gameTime)
        {
            var separator = new Separator();
            separator.X = 0;
            separator.Y = PlayerAreaHeight;

            var displayWidth = GlobalInstances.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            separator.Width = displayWidth;
            separator.Height = SeparatorHeight;

            separator.Draw(gameTime);
        }
    }
}
