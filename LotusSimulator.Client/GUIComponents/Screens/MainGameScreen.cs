using LotusSimulator.Client.Layout;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.GUIComponents.Screens
{
    public class MainGameScreen : Screen
    {
        private Layout.Layout _layout;

        public override void Draw(GameTime gameTime)
        {
            _layout?.Draw(gameTime);
        }

        private Layout.Layout BuildLayoutByPlayerCount()
        {
            var playerCount = GlobalInstances.GameState.Players.Count;
            switch (playerCount)
            {
                case 2:
                    return new TwoPlayersLayout();
                case 4:
                    return new FourPlayersLayout();
                default:
                    throw new NotImplementedException();
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (_layout == null)
            {
                _layout = BuildLayoutByPlayerCount();
            }

            _layout?.Update(gameTime);
        }

        public override void Dispose()
        {
            
        }
    }
}
