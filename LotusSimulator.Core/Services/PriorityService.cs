using LotusSimulator.Core.Entities.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class PriorityService
    {
        private readonly PlayabilityService _playabilityService;

        public PriorityService(PlayabilityService playableActionService)
        {
            _playabilityService = playableActionService;
        }

        public async Task GrantPriority(Player player)
        {
            var game = player.Game;
            game.PriorityHolder = player;

            await _playabilityService.SetPlayabilityAllPlayers(game);
        }
    }
}
