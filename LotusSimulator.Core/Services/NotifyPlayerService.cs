using LotusSimulator.Contract.Constants;
using LotusSimulator.Contract.MessageOut;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class NotifyPlayerService : INotifyPlayerService
    {
        private IHubContext<GameHub> _hubContext;
        public NotifyPlayerService(IHubContext<GameHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotifyGameStarted(GameStateCollectionDto gameStateCollection)
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



        public async Task NotifyCardChangeZone(GameChangeZoneCollectionDto cardChangeZone)
        {
            await _hubContext.Clients.All.SendAsync(Constants.CardChangeZoneMethod, cardChangeZone);
        }


        public async Task NotifyPlayabilityUpdate(PlayabilityCollectionDto playabilityCollection)
        {
            await _hubContext.Clients.Client(playabilityCollection.ConnectionId).SendAsync(Constants.PlayabilityUpdateMethod, playabilityCollection);
        }

        public async Task NotifyPriorityUpdate(PriorityUpdateDto priorityUpdate)
        {
            await _hubContext.Clients.All.SendAsync(Constants.PriorityUpdateMethod, priorityUpdate);
        }
    }
}
