using LotusSimulator.Client.Authorization;
using LotusSimulator.Contract.MessageIn;
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
        private Label _labelStartGame = new Label();
        private Button _buttonStartGame = new Button();

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
                grid.RowsProportions.Add(new Proportion());

                _labelP1.Text = "P1";
                _labelP1.Width = 100;
                _labelP1.Height = 50;
                Grid.SetRow(_labelP1, 0);

                _labelP2.Text = "P2";
                _labelP2.Width = 100;
                _labelP2.Height = 50;
                Grid.SetRow(_labelP2, 1);

                _labelStartGame = new Label();
                _labelStartGame.Text = "Start game";
                _buttonStartGame.Width = 100;
                _buttonStartGame.Height = 50;
                _buttonStartGame.Content = _labelStartGame;
                _buttonStartGame.Click += ButtonStartGame_Click;
                Grid.SetRow(_buttonStartGame, 2);

                grid.Widgets.Add(_labelP1);
                grid.Widgets.Add(_labelP2);
                grid.Widgets.Add(_buttonStartGame);

                GlobalInstances.Desktop.Root = grid;
            }
        }

        private void ButtonStartGame_Click(object sender, EventArgs e)
        {
            var startGameRequest = new StartGameRequestDto();
            startGameRequest.GameId = GlobalInstances.GamePreparationState.GameId;
            GlobalInstances.GameStateService.StartGameAsync(startGameRequest).GetAwaiter().GetResult();
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
