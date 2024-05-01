using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.DependencyInjection
{
    // Provides singlton SpriteBatch + GraphicDeviceManager (created from a Game instance)
    public interface IGameDependencyProvider
    {
        public GraphicsDeviceManager GetGraphicsDeviceManager();
        public SpriteBatch GetSpriteBatch();
    }
}
