using LotusSimulator.Client.Authorization;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.GUIComponents.Screens
{
    public class GamePreparationScreen : Screen
    {
        private bool _isDrawn;
        private Label _labelP1 = new Label();
        private Label _labelP2 = new Label();

        public override void Draw(GameTime gameTime)
        {
            if (!_isDrawn)
            {
                _isDrawn = true;

                var grid = new Grid();
                grid.Left = 0;
                grid.Top = 0;
                grid.RowsProportions.Add(new Proportion());
                grid.RowsProportions.Add(new Proportion());

                _labelP1.Text = "P1";
                _labelP1.Width = 100;
                _labelP1.Height = 50;
                Grid.SetRow(_labelP1, 0);

                _labelP2.Text = "P2";
                _labelP2.Width = 100;
                _labelP2.Height = 50;
                Grid.SetRow(_labelP2, 1);

                grid.Widgets.Add(_labelP1);
                grid.Widgets.Add(_labelP2);

                GlobalInstances.Desktop.Root = grid;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (GlobalInstances.GamePreparationState.Player == null
                || GlobalInstances.GamePreparationState.Player.Status == PlayerStatus.Disconnected)
            {
                GlobalInstances.GameStateService.ConnectToGameAsync().GetAwaiter().GetResult();
            }

            var player = GlobalInstances.GamePreparationState.Player;
            if (player != null)
            {
                _labelP1.Text = $"Player {player.ConnectionId}";
            }

            var opponents = GlobalInstances.GamePreparationState.Opponents;
            foreach (var opponent in opponents)
            {
                _labelP2.Text = $"Opponent {opponent.Nickname} slot: {opponent.Slot}";
            }
        }
    }
}
