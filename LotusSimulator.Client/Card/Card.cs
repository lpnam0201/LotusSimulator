using LotusSimulator.Client.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Card
{
    public class Card
    {
        public const int CardWidth = 50;
        public const int CardHeight = 70;

        private Texture2D _forest = HostedService.ContentManager.Load<Texture2D>("forest");
        private Texture2D _mtgBack = HostedService.ContentManager.Load<Texture2D>("mtg_card_back");

        public bool IsTapped { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; } = CardWidth;
        public int Height { get; set; } = CardHeight;

        private float rotation = 0;

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime)
        {
            HostedService.SpriteBatch.Draw(_mtgBack, new Rectangle(X, Y, Width, Height), Color.White);
        }
    }
}
