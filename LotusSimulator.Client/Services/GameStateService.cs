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
                string url = "http://localhost:80/gameHub";
                _hubConnection = new HubConnectionBuilder()
                    .WithUrl(url)
                    .WithAutomaticReconnect()
                    .Build();
                _hubConnection.On<GameStateDto>(Constants.ReceiveGameStateMethod, ReceiveGameStateHandler);
                await _hubConnection.StartAsync();   
            }

            await _hubConnection.InvokeAsync(Constants.PlayerJoinGameMethod);
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
