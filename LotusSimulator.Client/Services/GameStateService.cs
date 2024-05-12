using LotusSimulator.Client.Authorization;
using LotusSimulator.Contract.Constants;
using LotusSimulator.Contract.MessageIn;
using LotusSimulator.Contract.MessageOut;
using Microsoft.AspNetCore.SignalR.Client;
using System.Linq;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Services
{
    public class GameStateService
    {
        private HubConnection _hubConnection;
        private bool _isInitialized = false;

        private async Task EnsureServerConnectedAsync()
        {
            if (_hubConnection == null || _hubConnection.State != HubConnectionState.Disconnected)
            {
                string url = "https://localhost:7087/gameHub";
                _hubConnection = new HubConnectionBuilder()
                    .WithUrl(url)
                    .WithAutomaticReconnect()
                    .Build();
                _hubConnection.On<GameStateDto>(Constants.ReceiveGameStateMethod, ReceiveGameStateHandler);
                _hubConnection.On<GamePreparationResultDto>(Constants.GamePreparationUpdatedMethod, GamePreparationUpdatedHandler);
                //_hubConnection.On<InputRequestDto, InputResponseDto>("WaitForResponse", WaitForResponse);
                await _hubConnection.StartAsync();
            }
        }

        public async Task ConnectToGameAsync()
        {
            await EnsureServerConnectedAsync();

            var player = new Player();
            player.Status = PlayerStatus.Connecting;
            GlobalInstances.GamePreparationState.Player = player;

            var playerJoinGameResult = await _hubConnection.InvokeAsync<PlayerJoinGameResultDto>(
                Constants.PlayerJoinGameMethod, new PlayerJoinGameRequestDto());

            player.AccessToken = playerJoinGameResult.AccessToken;
            player.ConnectionId = _hubConnection.ConnectionId;
            player.Slot = playerJoinGameResult.Slot;
            player.Status = PlayerStatus.Connected;
        }

        public void GamePreparationUpdatedHandler(GamePreparationResultDto gamePreparationResult)
        {
            switch (gamePreparationResult.PlayerStatus.Status)
            {
                case GamePreparationPlayerStatus.Joined:
                    AddPlayerToGamePreparationState(gamePreparationResult);
                    break;
                case GamePreparationPlayerStatus.Left:
                    var leftOpponent = GlobalInstances.GamePreparationState.Opponents.First(x => x.Slot == gamePreparationResult.PlayerStatus.Slot);
                    GlobalInstances.GamePreparationState.Opponents.Remove(leftOpponent);
                    break;
                case GamePreparationPlayerStatus.LockedIn:
                    break;
            }
        }

        private void AddPlayerToGamePreparationState(GamePreparationResultDto gamePreparationResult)
        {
            if (GlobalInstances.GamePreparationState.Player.Slot != gamePreparationResult.PlayerStatus.Slot)
            {
                var joinedOpponent = new Opponent();
                joinedOpponent.Nickname = gamePreparationResult.PlayerStatus.Nickname;
                joinedOpponent.Slot = gamePreparationResult.PlayerStatus.Slot;
                GlobalInstances.GamePreparationState.Opponents.Add(joinedOpponent);
            }
        }

        private InputResponseDto WaitForResponse(InputRequestDto req)
        {
            var inputRes = new InputResponseDto();
            inputRes.Data = "2";
            return inputRes;
        }

        private void ReceiveGameStateHandler(GameStateDto gameState)
        {

        }



        public void SendPlayerInputAsync(PlayerInputDto playerInput)
        {
            //_hubConnection.InvokeAsync()
        }
    }
}
