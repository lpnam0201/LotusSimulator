using LotusSimulator.Client.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LotusSimulator.Client
{
    public class LotusSimulatorGame : Game, IGame
    {
        public Game Game => this;

        private Texture2D _mtgCardBack;
        private SpriteBatch _spriteBatch;

        public LotusSimulatorGame()
        {
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _mtgCardBack = this.Content.Load<Texture2D>("mtg_card_back");
            

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            _spriteBatch.Begin();

            var initialX = 100;
            var initialY = 100;
            var cardRectangle = new Rectangle(initialX, initialY, 100, 139);


            var sourceRectangle = new Rectangle(0, 0, _mtgCardBack.Width, _mtgCardBack.Height);
            for (var i = 0; i < 30; i++)
            {
                cardRectangle.X = initialX - i;
                cardRectangle.Y = initialY - i;
                _spriteBatch.Draw(_mtgCardBack, cardRectangle, sourceRectangle, color: Color.White);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}