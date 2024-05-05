using LotusSimulator.Contract.Constants;
using LotusSimulator.Contract.MessageIn;
using LotusSimulator.Contract.MessageOut;
using LotusSimulator.Core;
using Microsoft.AspNetCore.SignalR;

namespace LotusSimulator
{
    public class GameHub : Hub
    {
        public async Task PlayerJoinGame(PlayerJoinGameDto playerJoinGame)
        {
            // 
        }
    }
}
