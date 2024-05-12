using LotusSimulator.Contract.Constants;
using LotusSimulator.Contract.MessageIn;
using LotusSimulator.Contract.MessageOut;
using LotusSimulator.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.MessageOut
{
    public class GameStateService
    {

        private IHubContext<GameHub> _hubContext;

        public GameStateService(IHubContext<GameHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendGameStates(GameStateCollectionDto gameStateCollection)
        {
            foreach (var kvp in gameStateCollection.GameStates)
            {
                var userId = kvp.Key;
                var gameState = kvp.Value;
                await _hubContext.Clients.User(userId).SendAsync(Constants.ReceiveGameStateMethod, gameState);
            }
        }

        public async Task SendGamePreparationResultAsync(GamePreparationResultDto gamePreparationResult)
        {
            await _hubContext.Clients.All.SendAsync(Constants.GamePreparationUpdatedMethod, gamePreparationResult);
        }


    }
}
