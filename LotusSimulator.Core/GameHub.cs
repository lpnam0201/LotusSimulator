using LotusSimulator.Contract.Constants;
using LotusSimulator.Contract.MessageIn;
using LotusSimulator.Contract.MessageOut;
using LotusSimulator.Core;
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
        }

        public async Task a()
        {

        }
    }
}
