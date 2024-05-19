using LotusSimulator.Contract.Constants;
using LotusSimulator.Contract.MessageIn;
using LotusSimulator.Core.Entities.Card;
using LotusSimulator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class PlayerInputService
    {
        private LandService _landService;

        public PlayerInputService(LandService landService)
        {
            _landService = landService;
        }

        public async Task Dispatch(PlayerInputDto playerInput, Game game)
        {
            
            switch (playerInput.Playability.Type)
            {
                case PlayabilityType.PlayAsLand:
                    var card = game.FindCard(playerInput.Playability.ObjectId);
                    var playerWhoPlay = game.GetPlayerByConnectionId(playerInput.Playability.PlayableByPlayerId);
                    await _landService.PlayLand(card, playerWhoPlay);
                    break;
                case PlayabilityType.Cast:

                    break;
                case PlayabilityType.Activate:

                    break;
                default:
                    break;
            }
        }
    }
}
