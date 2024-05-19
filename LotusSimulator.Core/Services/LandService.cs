using LotusSimulator.Core.Entities.Card;
using LotusSimulator.Core.Entities.Players;
using LotusSimulator.Core.MessageOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class LandService
    {
        private readonly PermanentService _permanentService;
        private readonly GameStateService _gameStateService;
        private readonly GameStateMapper _gameStateMapper;

        public LandService(PermanentService permanentService, GameStateService gameStateService, GameStateMapper gameStateMapper)
        {
            _permanentService = permanentService;
            _gameStateService = gameStateService;
            _gameStateMapper = gameStateMapper;
        }

        public async Task PlayLand(Card card, Player playerWhoPlay)
        {
            if (playerWhoPlay.LandPlayed >= playerWhoPlay.LandPlaysPerTurn)
            {
                return;
            }

            var sourceZone = card.CardZone;
            var battlefield = playerWhoPlay.Battlefield;

            var permanent = Permanent.FromCard(card, playerWhoPlay);

            // todo remove from zone via service
            sourceZone.Remove(card);

            await _permanentService.EntersBattlefield(
                new List<Permanent>
                {
                    permanent
                }, battlefield);
            var cardChangeZone = _gameStateMapper.BuildCardChangeZoneDto(
                card,
                sourceZone.Zone,
                card.Owner.ConnectionId,
                permanent,
                battlefield.Zone,
                playerWhoPlay.ConnectionId);
            await _gameStateService.SendCardChangeZone(cardChangeZone);
        }


    }
}
