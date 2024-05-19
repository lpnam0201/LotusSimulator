using LotusSimulator.Core.Entities.Card;
using LotusSimulator.Core.Entities.Players;
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

        public LandService(PermanentService permanentService)
        {
            _permanentService = permanentService;
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
        }


    }
}
