﻿using LotusSimulator.Contract.MessageOut;
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

        public PriorityService(PlayabilityService playableActionService, GameStateService gameStateService, TurnOrderService turnOrderService)
        {
            _playabilityService = playableActionService;
            _gameStateService = gameStateService;
            _turnOrderService = turnOrderService;
        }

        public async Task GrantPriority(Player player)
        {
            var game = player.Game;
            game.PriorityHolder = player;

            await _playabilityService.SetPlayabilityAllPlayers(game);
            var prioritySlot = game.PlayerSlots.First(x => x.Value == game.PriorityHolder).Key;
            await _gameStateService.SendPriorityUpdate(new PriorityUpdateDto
            { 
                PriorityHolderSlot = prioritySlot
            });
        }

        public async Task PassPriority(Game game)
        {
            var nextPlayerForPriority = _turnOrderService.GetNextPlayerForPriority(game);
            game.PassedPrioritiesWithNoAction += 1;

            await GrantPriority(nextPlayerForPriority);
        }

        public bool IsAllPlayerPassedInSuccession(Game game)
        {
            return game.Players.Count == game.PassedPrioritiesWithNoAction;
        }
    }
}
