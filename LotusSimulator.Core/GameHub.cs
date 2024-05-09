using LotusSimulator.Contract.MessageIn;
using LotusSimulator.Contract.MessageOut;
using LotusSimulator.Core.Services;
using Microsoft.AspNetCore.SignalR;

namespace LotusSimulator
{
    public class GameHub : Hub
    {
        public GameContainer _gameContainer;

        public GameHub(GameContainer gameContainer)
        {
            _gameContainer = gameContainer;
        }

        public async Task PlayerJoinGame(PlayerJoinGameDto playerJoinGame)
        {
            var connectionId = Context.ConnectionId;
            _gameContainer.AssignPlayerToGame(connectionId);

            var inputRequest = new InputRequestDto();
            inputRequest.Data = "1";
            var res = await Clients.Client(connectionId).InvokeAsync<InputResponseDto>("WaitForResponse", inputRequest, CancellationToken.None);
        }
    }
}
