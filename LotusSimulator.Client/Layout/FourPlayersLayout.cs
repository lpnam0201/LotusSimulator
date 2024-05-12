using Microsoft.Xna.Framework;

namespace LotusSimulator.Client.Layout
{
    public class FourPlayersLayout : Layout
    {
        private const int PlayerAreaWidth = 900;
        private const int PlayerAreaHeight = 450;

        private const int SeparatorHeight = 40;

        private const int TopPlayerDistFromTop = 0;

        private const int TopPlayerHorizontalGap = 1920 - PlayerAreaWidth * 2;
        private const int FirstTopPlayerDistFromLeft = 0;
        private const int SecondTopPlayerDistFromLeft = FirstTopPlayerDistFromLeft + PlayerAreaWidth + TopPlayerHorizontalGap;

        private const int BottomPlayerDistFromTop = 0 + PlayerAreaHeight + SeparatorHeight;

        private const int BottomPlayerHorizontalGap = 1920 - PlayerAreaWidth * 2;
        private const int FirstBottomPlayerDistFromLeft = 0;
        private const int SecondBottomPlayerDistFromLeft = FirstBottomPlayerDistFromLeft + PlayerAreaWidth + BottomPlayerHorizontalGap;

        public FourPlayersLayout()
        {
        }

        public override void Draw(GameTime gameTime)
        {
            DrawTopPlayerArea(gameTime, FirstTopPlayerDistFromLeft);
            DrawTopPlayerArea(gameTime, SecondTopPlayerDistFromLeft);
            DrawBottomPlayerArea(gameTime, FirstBottomPlayerDistFromLeft, BottomPlayerDistFromTop);
            DrawBottomPlayerArea(gameTime, SecondBottomPlayerDistFromLeft, BottomPlayerDistFromTop);

            DrawSeparator(gameTime);
        }

        public override void Update(GameTime gameTime)
        {

        }

        private void DrawTopPlayerArea(GameTime gameTime, int x)
        {
            var topPlayer = new TopPlayerArea();
            topPlayer.X = x;
            topPlayer.Y = TopPlayerDistFromTop;

            topPlayer.Width = PlayerAreaWidth;
            topPlayer.Height = PlayerAreaHeight;

            topPlayer.Draw(gameTime);
        }

        private void DrawBottomPlayerArea(GameTime gameTime, int x, int y)
        {
            var bottomPlayer = new BottomPlayerArea();
            bottomPlayer.X = x;
            bottomPlayer.Y = BottomPlayerDistFromTop;

            bottomPlayer.Width = PlayerAreaWidth;
            bottomPlayer.Height = PlayerAreaHeight;

            bottomPlayer.Draw(gameTime);
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
