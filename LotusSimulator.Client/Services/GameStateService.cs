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

        public async Task RunAsync()
        {
            if (_isInitialized)
            {
                return;
            }

            string url = "http://localhost:8080";
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect()
                .Build();
            _hubConnection.On<GameStateDto>(Constants.ReceiveGameStateMethod, ReceiveGameStateHandler);

            await _hubConnection.StartAsync();
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
