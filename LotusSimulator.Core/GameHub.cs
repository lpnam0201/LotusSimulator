using LotusSimulator.Contract.Constants;
using LotusSimulator.Contract.MessageOut;
using Microsoft.AspNetCore.SignalR;

namespace LotusSimulator
{
    public class GameHub : Hub
    {
        public async Task SendGameStates(GameStateCollectionDto gameStateCollection)
        {
            foreach (var kvp in gameStateCollection.GameStates)
            {
                var userId = kvp.Key;
                var gameState = kvp.Value;
                await Clients.User(userId).SendAsync(Constants.ReceiveGameStateMethod, gameState);
            }
        }
    }
}
