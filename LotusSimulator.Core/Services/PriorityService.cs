using LotusSimulator.Contract.MessageOut;
using LotusSimulator.Core.Entities.Players;
using LotusSimulator.Core.MessageOut;
using LotusSimulator.Entities;
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
        private readonly GameStateService _gameStateService;
        private readonly TurnOrderService _turnOrderService;
        private readonly GameStateMapper _gameStateMapper;

        public PriorityService(PlayabilityService playableActionService, GameStateService gameStateService, TurnOrderService turnOrderService, GameStateMapper gameStateMapper)
        {
            _playabilityService = playableActionService;
            _gameStateService = gameStateService;
            _turnOrderService = turnOrderService;
            _gameStateMapper = gameStateMapper;
        }

        public async Task GrantPriority(Player player)
        {
            var game = player.Game;
            game.PriorityHolder = player;

            await _playabilityService.SetPlayabilityAllPlayers(game);
            var playabilityCollection = _gameStateMapper.BuildPlayabilityCollectionDto(game, player.ConnectionId);
            await _gameStateService.SendPlayabilityUpdate(playabilityCollection);

            var priorityConnectionId = game.Players.FirstOrDefault(x => x == game.PriorityHolder).ConnectionId;
            await _gameStateService.SendPriorityUpdate(new PriorityUpdateDto
            {
                PriorityHolderId = priorityConnectionId
            });
        }

        public async Task PassPriority(Game game)
        {
            game.PriorityHolder = null;
            game.PassedPrioritiesWithNoAction += 1;
        }

        public bool IsAllPlayerPassedInSuccession(Game game)
        {
            return game.Players.Count == game.PassedPrioritiesWithNoAction;
        }
    }
}
