using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.DependencyInjection
{
    public class GameDependencyProvider : IGameDependencyProvider
    {
        private IGame _game;
        private GraphicsDeviceManager _graphicsDeviceManager;
        private SpriteBatch _spriteBatch;

        public GameDependencyProvider(IGame game)
        {
            _game = game;
        }

        public GraphicsDeviceManager GetGraphicsDeviceManager()
        {
            if (_graphicsDeviceManager == null)
            {
                _graphicsDeviceManager = new GraphicsDeviceManager(_game.Game);
            }

            return _graphicsDeviceManager;
        }

        public SpriteBatch GetSpriteBatch()
        {
            if (_spriteBatch == null)
            {
                _spriteBatch = new SpriteBatch(_game.Game.GraphicsDevice);
            }

            return _spriteBatch;
        }
    }
}
