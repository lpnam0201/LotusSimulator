﻿using LotusSimulator.Client.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Layout
{
    public class LayoutManager
    {
        private TwoPlayersLayout _twoPlayersLayout;

        public LayoutManager()
        {
            _twoPlayersLayout = new TwoPlayersLayout();
        }

        public void Draw(GameTime gameTime)
        {
            _twoPlayersLayout.Draw(gameTime);
        }

        public void Update(GameTime gameTime)
        {
            _twoPlayersLayout.Update(gameTime);
        }
    }
}
