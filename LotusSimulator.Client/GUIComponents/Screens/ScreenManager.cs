using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.GUIComponents.Screens
{
    public class ScreenManager
    {
        private ScreenKind _screenKind;
        private Screen _currentScreen;

        public void SetScreenKind(ScreenKind screenKind)
        {
            _screenKind = screenKind;
            switch (screenKind)
            {
                case ScreenKind.Start:
                    _currentScreen = new StartScreen();
                    break;
                case ScreenKind.GamePreparation:
                    _currentScreen = new GamePreparationScreen();
                    return;
                case ScreenKind.GameLobby:
                    return;
                case ScreenKind.None:
                    return;
            }
        }

        public void Draw(GameTime gameTime)
        {
            _currentScreen?.Draw(gameTime);
        }

        public void Update(GameTime gameTime)
        {
            _currentScreen?.Update(gameTime);
        }
    }
}
