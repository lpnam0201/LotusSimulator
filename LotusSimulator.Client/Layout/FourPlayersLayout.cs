using LotusSimulator.Client.DependencyInjection;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Layout
{
    public class FourPlayersLayout
    {
        private const int PlayerAreaWidth = 800;
        private const int PlayerAreaHeight = 450;

        private const int TopPlayerHorizontalGap = 1920 - PlayerAreaWidth * 2;
        private const int FirstTopPlayerDistFromLeft = 0;
        private const int SecondTopPlayerDistFromLeft = FirstTopPlayerDistFromLeft + PlayerAreaWidth + TopPlayerHorizontalGap;

        public FourPlayersLayout()
        {
        }

        public void Draw(GameTime gameTime)
        {
            DrawTopPlayerArea(gameTime, FirstTopPlayerDistFromLeft);
            DrawTopPlayerArea(gameTime, SecondTopPlayerDistFromLeft);

            DrawSeparator(gameTime);
        }

        public void Update(GameTime gameTime)
        {

        }

        private void DrawTopPlayerArea(GameTime gameTime, int x)
        {
            var topPlayer = new TopPlayerArea();
            topPlayer.X = x;
            topPlayer.Y = 0;

            topPlayer.Width = PlayerAreaWidth;
            topPlayer.Height = PlayerAreaHeight;

            topPlayer.Draw(gameTime);
        }

        private void DrawSeparator(GameTime gameTime)
        {
            var separator = new Separator();
            separator.X = 0;
            separator.Y = PlayerAreaHeight;

            var displayWidth = HostedService.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            separator.Width = displayWidth;
            separator.Height = 40;

            separator.Draw(gameTime);
        }
    }
}
