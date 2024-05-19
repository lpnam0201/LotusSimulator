using LotusSimulator.Client.Authorization;
using LotusSimulator.Client.GUIComponents.Screens;
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
                _hubConnection.On<GameStateDto>(Constants.GameStartedMethod, GameStartedHandler);
                _hubConnection.On(Constants.MulliganOfferMethod, MulliganOfferedHandler);
                _hubConnection.On<PlayabilityCollectionDto>(Constants.PlayabilityUpdateMethod, PlayabilityUpdateHandler);
                _hubConnection.On<PriorityUpdateDto>(Constants.PriorityUpdateMethod, PriorityUpdateHandler);
                _hubConnection.On<GameChangeZoneCollectionDto>(Constants.CardChangeZoneMethod, CardChangeZoneHandler);
                //_hubConnection.On<InputRequestDto, InputResponseDto>("WaitForResponse", WaitForResponse);
                await _hubConnection.StartAsync();
            }
        }

        public async Task ConnectToGameAsync()
        {
            await EnsureServerConnectedAsync();

            var player = new PlayerIdentity();
            player.Status = PlayerStatus.Connecting;
            GlobalInstances.GamePreparationState.Player = player;

            var playerJoinGameResult = await _hubConnection.InvokeAsync<PlayerJoinGameResultDto>(
                Constants.PlayerJoinGameMethod, new PlayerJoinGameRequestDto());

            player.AccessToken = playerJoinGameResult.AccessToken;
            player.ConnectionId = _hubConnection.ConnectionId;
            player.Slot = playerJoinGameResult.Slot;
            player.Status = PlayerStatus.Connected;

            GlobalInstances.GamePreparationState.GameId = playerJoinGameResult.GameId;
            GlobalInstances.YourConnectionId = _hubConnection.ConnectionId;
        }

        private void GamePreparationUpdatedHandler(GamePreparationResultDto gamePreparationResult)
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
                var joinedOpponent = new OpponentIdentity();
                joinedOpponent.Nickname = gamePreparationResult.PlayerStatus.Nickname;
                joinedOpponent.Slot = gamePreparationResult.PlayerStatus.Slot;
                GlobalInstances.GamePreparationState.Opponents.Add(joinedOpponent);
            }
        }

        private async Task<MulliganOfferResultDto> MulliganOfferedHandler()
        {
            return await GlobalInstances.ModalService.OpenMulliganPopup();
        }

        private async Task PlayabilityUpdateHandler(PlayabilityCollectionDto playabilityCollection)
        {
            GlobalInstances.PlayabilityUpdateService.Update(playabilityCollection);
        }

        private async Task PriorityUpdateHandler(PriorityUpdateDto priorityUpdate)
        {
            GlobalInstances.GameDisplayModel.PriorityHolder = priorityUpdate.PriorityHolderId;
        }

        private void ReceiveGameStateHandler(GameStateDto gameState)
        {
            GlobalInstances.GameDisplayModel = GlobalInstances.DisplayModelMapper.MapToDisplayModel(gameState);
        }

        private async Task CardChangeZoneHandler(GameChangeZoneCollectionDto cardChangeZone)
        {
            GlobalInstances.CardChangeZoneUpdateService.MoveGameObject(cardChangeZone);
        }

        public async Task StartGameAsync(StartGameRequestDto startGameRequest)
        {
            // must use send
            await _hubConnection.SendAsync(Constants.StartGameMethod, startGameRequest);
        }

        private void GameStartedHandler(GameStateDto gameState)
        {
            GlobalInstances.GameDisplayModel = GlobalInstances.DisplayModelMapper.MapToDisplayModel(gameState);
            GlobalInstances.ScreenManager.SetScreenKind(ScreenKind.MainGame);
        }

        public async Task PassPriority(PassPriorityDto passPriority)
        {
            await _hubConnection.SendAsync(Constants.PassPriorityMethod, passPriority);
        }

        public async Task SendPlayerInputAsync(PlayerInputDto playerInput)
        {
            await _hubConnection.SendAsync(Constants.PlayerInputMethod, playerInput);
        }
    }
}
