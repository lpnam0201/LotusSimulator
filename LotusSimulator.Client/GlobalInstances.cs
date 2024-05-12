﻿using LotusSimulator.Client.Authorization;
using LotusSimulator.Client.GUIComponents.Screens;
using LotusSimulator.Client.Services;
using LotusSimulator.Contract.MessageOut;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client
{
    public static class GlobalInstances
    {
        public static SpriteBatch SpriteBatch { get; set; }
        public static Desktop Desktop { get; set; }
        public static GraphicsDevice GraphicsDevice { get; set; }
        public static ContentManager ContentManager { get; set; }
        public static LookupCardImageService LookupCardImageService { get; set; } = new LookupCardImageService();
        public static GameStateService GameStateService { get; set; }
        public static ScreenManager ScreenManager { get; set; }
        public static GamePreparationState GamePreparationState { get; set; } = new GamePreparationState();
        public static GameStateDto GameState { get; set; }
        
    }
}
