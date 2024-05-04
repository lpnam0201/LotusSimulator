using LotusSimulator.Client.DependencyInjection;
using LotusSimulator.Client.Layout;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LotusSimulator.Client
{
    public class LotusSimulatorGame : Game, IGame
    {
        public Game Game => this;

        private Texture2D _mtgCardBack;
        private LayoutManager _layoutManager;

        public LotusSimulatorGame(LayoutManager layoutManager)
        {
            _layoutManager = layoutManager;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //_mtgCardBack = this.Content.Load<Texture2D>("mtg_card_back");
            //_mtgCardBack = this.Content.Load<Texture2D>("life_total");
            

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _layoutManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            HostedService.SpriteBatch.Begin();

            _layoutManager.Draw(gameTime);

            HostedService.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}