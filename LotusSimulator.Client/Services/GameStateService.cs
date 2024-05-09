using LotusSimulator.Contract.Constants;
using LotusSimulator.Contract.MessageIn;
using LotusSimulator.Contract.MessageOut;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Services
{
    public class GameStateService
    {
        private HubConnection _hubConnection;
        private bool _isInitialized = false;

        public async Task ConnectToGameAsync()
        {
            if (_hubConnection == null || _hubConnection.State != HubConnectionState.Disconnected)
            {
                string url = "https://localhost:7087/gameHub";
                _hubConnection = new HubConnectionBuilder()
                    .WithUrl(url)
                    .WithAutomaticReconnect()
                    .Build();
                _hubConnection.On<GameStateDto>(Constants.ReceiveGameStateMethod, ReceiveGameStateHandler);
                _hubConnection.On<InputRequestDto, InputResponseDto>("WaitForResponse", WaitForResponse);
                await _hubConnection.StartAsync();   
            }

            await _hubConnection.InvokeAsync(Constants.PlayerJoinGameMethod, new PlayerJoinGameDto());
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
