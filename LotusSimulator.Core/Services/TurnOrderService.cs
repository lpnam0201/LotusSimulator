using LotusSimulator.Core.Entities.Players;
using LotusSimulator.Core.Entities.Turn;
using LotusSimulator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class TurnOrderService
    {
        public Player GetNextPlayerForPriority(Game game, Player currentPriorityHolder)
        {
            var currentPlayerIndex = game.TurnOrderIds.IndexOf(currentPriorityHolder.ConnectionId);

            var nextIndex = (currentPlayerIndex + 1) % game.TurnOrderIds.Count;
            var connectionId = game.TurnOrderIds[nextIndex];

            return game.Players.FirstOrDefault(x => x.ConnectionId == connectionId);
        }

        public Player GetNextPlayerForTurn(Game game)
        {
            var currentPlayerIndex = game.TurnOrderIds.IndexOf(game.CurrentTurn.Player.ConnectionId);

            var nextIndex = (currentPlayerIndex + 1) % game.TurnOrderIds.Count;
            var connectionId = game.TurnOrderIds[nextIndex];

            return game.Players.FirstOrDefault(x => x.ConnectionId == connectionId);
        }

        public void SetTurnOrder(Game game, string goFirstConnectionId)
        {
            var goFirstPlayerIndex = game.Players
                .Select(x => x.ConnectionId)
                .ToList()
                .IndexOf(goFirstConnectionId);
            var playerCount = game.Players.Count;

            game.TurnOrderIds.Add(goFirstConnectionId);
            do
            {
                var nextPlayerIndex = (goFirstPlayerIndex + 1) % playerCount;
                var nextPlayerConnectionId = game.Players[nextPlayerIndex].ConnectionId;
                game.TurnOrderIds.Add(nextPlayerConnectionId);

            } while (game.TurnOrderIds.Count < playerCount);
        }
    }
}
