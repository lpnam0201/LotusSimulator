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
            var sendToClientTasks = new List<Task>();
            foreach (var kvp in gameStateCollection.GameStates)
            {
                var connectionId = kvp.Key;
                var gameState = kvp.Value;
                var task = _hubContext.Clients.Client(connectionId).SendAsync(Constants.ReceiveGameStateMethod, gameState);
                sendToClientTasks.Add(task);
            }

            await Task.WhenAll(sendToClientTasks);
        }

        public async Task SendGameStarted(GameStateCollectionDto gameStateCollection)
        {
            var sendToClientTasks = new List<Task>();
            foreach (var kvp in gameStateCollection.GameStates)
            {
                var connectionId = kvp.Key;
                var gameState = kvp.Value;
                var task = _hubContext.Clients.Client(connectionId).SendAsync(Constants.GameStartedMethod, gameState);
                sendToClientTasks.Add(task);
            }

            await Task.WhenAll(sendToClientTasks);
        }



        public async Task SendGamePreparationResultAsync(GamePreparationResultDto gamePreparationResult)
        {
            await _hubContext.Clients.All.SendAsync(Constants.GamePreparationUpdatedMethod, gamePreparationResult);
        }


    }
}
