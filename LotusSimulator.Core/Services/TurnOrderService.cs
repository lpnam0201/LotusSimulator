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
        public Player GetNextPlayerForPriority(Game game)
        {
            var currentSlot = game.PlayerSlots.FirstOrDefault(x => x.Value == game.PriorityHolder).Key;
            var slots = game.PlayerSlots.Values;

            var nextSlot = (currentSlot + 1) % slots.Count;
            return game.PlayerSlots[nextSlot];
        }

        public Player GetNextPlayerForTurn(Game game)
        {
            var currentSlot = game.PlayerSlots.FirstOrDefault(x => x.Value == game.CurrentTurn.Player).Key;
            var slots = game.PlayerSlots.Values;

            var nextSlot = (currentSlot + 1) % slots.Count;
            return game.PlayerSlots[nextSlot];
        }
    }
}
