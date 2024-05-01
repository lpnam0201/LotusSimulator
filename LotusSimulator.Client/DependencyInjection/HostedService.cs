using Microsoft.Extensions.Hosting;
using Microsoft.Xna.Framework;
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
        private readonly IGame _game;
        private readonly IHostApplicationLifetime _appLifetime;

        public HostedService(IGame game, IHostApplicationLifetime appLifetime, IGameDependencyProvider gameDependencyProvider)
        {
            _game = game;
            _appLifetime = appLifetime;

            var graphicsDeviceManager = gameDependencyProvider.GetGraphicsDeviceManager();
            if (graphicsDeviceManager != null)
            {
                graphicsDeviceManager.ApplyChanges();
            }

            graphicsDeviceManager.IsFullScreen = false;
            graphicsDeviceManager.PreferredBackBufferWidth = game.Game.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            graphicsDeviceManager.PreferredBackBufferHeight = game.Game.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            graphicsDeviceManager.ApplyChanges();
            game.Game.Content.RootDirectory = "Content";
            game.Game.IsMouseVisible = true;
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
