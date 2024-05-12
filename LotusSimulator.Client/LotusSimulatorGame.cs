using LotusSimulator.Client.Global;
using LotusSimulator.Client.GUIComponents.Screens;
using LotusSimulator.Client.Layout;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Myra;
using Myra.Graphics2D.UI;

namespace LotusSimulator.Client
{
    public class LotusSimulatorGame : Game
    {
        public Game Game => this;

        private Desktop Desktop;
        //private ScreenManager _screenManager = new ScreenManager();
        private GraphicsDeviceManager _graphicsDeviceManager;
        private SpriteBatch _spriteBatch;

        public LotusSimulatorGame()
        {
            IsMouseVisible = true;
            _graphicsDeviceManager = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;

            GlobalInstances.ContentManager = Content;
        }

        protected override void Initialize()
        {
            base.Initialize();

            // TODO: Add your initialization logic here
            if (_graphicsDeviceManager != null)
            {
                _graphicsDeviceManager.ApplyChanges();
            }

            _graphicsDeviceManager.IsFullScreen = false;
            _graphicsDeviceManager.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            _graphicsDeviceManager.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            _graphicsDeviceManager.ApplyChanges();

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            GlobalInstances.SpriteBatch = _spriteBatch;

            GlobalInstances.GraphicsDevice = GraphicsDevice;
            var screenManager = new ScreenManager();
            screenManager.SetScreenKind(ScreenKind.Start);
            GlobalInstances.ScreenManager = screenManager;
        }

        protected override void LoadContent()
        {
            MyraEnvironment.Game = this;
            Desktop = new Desktop();
            GlobalInstances.Desktop = Desktop;

            // TODO: use this.Content to load your game content here
            ContentTextures.MTGBack = GlobalInstances.ContentManager.Load<Texture2D>("mtg_card_back");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //_layoutManager.Update(gameTime);
            GlobalInstances.ScreenManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            GlobalInstances.SpriteBatch.Begin();
            GlobalInstances.ScreenManager.Draw(gameTime);
            GlobalInstances.SpriteBatch.End();

            // Must be after SpriteBatch End, otherwise UI dialogs will show beneath game elements
            Desktop.Render();

            base.Draw(gameTime);
        }
    }
}