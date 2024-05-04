using Microsoft.Extensions.Hosting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LotusSimulator.Client.DependencyInjection
{
    public class HostedService : IHostedService
    {
        public static SpriteBatch SpriteBatch { get; private set; }
        public static GraphicsDeviceManager GraphicsDeviceManager { get; private set; }
        public static GraphicsDevice GraphicsDevice { get; private set; }
        public static ContentManager ContentManager { get; private set; }

        private readonly IGame _game;
        private readonly IHostApplicationLifetime _appLifetime;

        public HostedService(IGame game, IHostApplicationLifetime appLifetime)
        {
            _game = game;
            _appLifetime = appLifetime;

            GraphicsDeviceManager = new GraphicsDeviceManager(game.Game);
            if (GraphicsDeviceManager != null)
            {
                GraphicsDeviceManager.ApplyChanges();
            }

            GraphicsDeviceManager.IsFullScreen = false;
            GraphicsDeviceManager.PreferredBackBufferWidth = game.Game.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            GraphicsDeviceManager.PreferredBackBufferHeight = game.Game.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            GraphicsDeviceManager.ApplyChanges();
            game.Game.Content.RootDirectory = "Content";
            game.Game.IsMouseVisible = true;
            game.Game.Window.AllowUserResizing = true;

            SpriteBatch = new SpriteBatch(game.Game.GraphicsDevice);
            GraphicsDevice = game.Game.GraphicsDevice;
            ContentManager = game.Game.Content;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStarted.Register(OnStarted);
            _appLifetime.ApplicationStopping.Register(OnStopping);
            _appLifetime.ApplicationStopped.Register(OnStopped);

            _game.Exiting += OnGameExiting;

            return Task.CompletedTask;
        }

        private void OnGameExiting(object sender, System.EventArgs e)
        {
            StopAsync(new CancellationToken());
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _appLifetime.StopApplication();

            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            _game.Run();
        }

        private void OnStopping()
        {
        }

        private void OnStopped()
        {
        }
    }
}
