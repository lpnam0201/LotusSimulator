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

        public TwoPlayersLayout()
        {
        }

        public void Draw(GameTime gameTime)
        {
            DrawTopPlayerArea(gameTime);
            DrawBottomPlayerArea(gameTime);

            DrawSeparator(gameTime);
        }

        public void Update(GameTime gameTime)
        {
            
        }

        private void DrawTopPlayerArea(GameTime gameTime)
        {
            var displayWidth = HostedService.GraphicsDevice.Adapter.CurrentDisplayMode.Width;

            var topPlayer = new TopPlayerArea();
            topPlayer.X = displayWidth / 2 - PlayerAreaWidth / 2;
            topPlayer.Y = 0;

            topPlayer.Width = PlayerAreaWidth;
            topPlayer.Height = PlayerAreaHeight;

            topPlayer.Draw(gameTime);
        }

        private void DrawBottomPlayerArea(GameTime gameTime)
        {
            var displayWidth = HostedService.GraphicsDevice.Adapter.CurrentDisplayMode.Width;

            var topPlayer = new BottomPlayerArea();
            topPlayer.X = displayWidth / 2 - PlayerAreaWidth / 2;
            topPlayer.Y = BottomPlayerDistFromTop;

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
            separator.Height = SeparatorHeight;

            separator.Draw(gameTime);
        }
    }
}
