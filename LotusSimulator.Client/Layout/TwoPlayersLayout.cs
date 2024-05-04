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
        private const int PlayerAreaWidth = 800;
        private const int PlayerAreaHeight = 450;

        public TopPlayerArea TopPlayerArea;

        public TwoPlayersLayout()
        {
        }

        public void Draw(GameTime gameTime)
        {
            DrawTopPlayerArea(gameTime);

            DrawSeparator(gameTime);

            //var displayHeight = HostedService.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            //DrawPlayerArea(0, displayHeight / 2 + 20, false);
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
