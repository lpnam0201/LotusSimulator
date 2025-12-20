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
        private readonly IUserInputService _userInputService;
        private readonly GameStateMapper _gameStateMapper;
        private readonly INotifyPlayerService _notifyPlayerService;

        public LandService(PermanentService permanentService, IUserInputService userInputService, GameStateMapper gameStateMapper, INotifyPlayerService notifyPlayerService)
        {
            _permanentService = permanentService;
            _userInputService = userInputService;
            _gameStateMapper = gameStateMapper;
            _notifyPlayerService = notifyPlayerService;
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
            await _notifyPlayerService.NotifyCardChangeZone(cardChangeZone);
        }


    }
}
