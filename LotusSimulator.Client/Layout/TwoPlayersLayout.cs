using Microsoft.Xna.Framework;
using System.Linq;

namespace LotusSimulator.Client.Layout
{
    public class TwoPlayersLayout : Layout
    {
        private const int PlayerAreaWidth = 900;
        private const int PlayerAreaHeight = 450;

        private const int SeparatorHeight = 40;

        private const int BottomPlayerDistFromTop = PlayerAreaHeight + SeparatorHeight;

        private TopPlayerAreaZone _topPlayerArea;
        private BottomPlayerAreaZone _bottomPlayerArea;

        public TwoPlayersLayout()
        {
            _topPlayerArea = new TopPlayerAreaZone();
            _bottomPlayerArea = new BottomPlayerAreaZone();
        }

        public override void Draw(GameTime gameTime)
        {
            DrawTopPlayerArea(gameTime);
            DrawBottomPlayerArea(gameTime);

            DrawSeparator(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            _topPlayerArea.ConnectionId = GlobalInstances.GameDisplayModel.GameState.Players
                .FirstOrDefault(x => x.Id != GlobalInstances.GameDisplayModel.YourConnectionId)
                .Id;
            _topPlayerArea.Update(gameTime);

            _bottomPlayerArea.ConnectionId = GlobalInstances.GameDisplayModel.YourConnectionId;
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
