using LotusSimulator.Contract.MessageOut;
using LotusSimulator.Core.Entities.Players;
using LotusSimulator.Core.Entities.Zones;
using LotusSimulator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class GameStateMapper
    {
        public GameStateCollectionDto BuildGameStateCollection(Game game)
        {
            var gameStateCollection = new GameStateCollectionDto();
            foreach (var kvp in game.PlayerIds)
            {
                var connectionId = kvp.Key;
                var gameState = new GameStateDto();

                foreach (var player in game.Players)
                {
                    PlayerDto playerDto;
                    if (player.ConnectionId == connectionId)
                    {
                        playerDto = MapForPlayerOwnView(player);
                    }
                    else
                    {
                        playerDto = MapForPlayerStrangerView(player);
                    }
                    gameState.Players.Add(playerDto);
                }

                gameStateCollection.GameStates.Add(connectionId, gameState);
            }

            return gameStateCollection;
        }

        private PlayerDto MapForPlayerOwnView(Player player)
        {
            var playerDto = new PlayerDto();
            playerDto.Battlefield = MapBattlefield(player.Battlefield);
            playerDto.Hand = MapHandOwnView(player.Hand);

            return playerDto;
        }

        private BattlefieldDto MapBattlefield(Battlefield battlefield)
        {
            var battlefieldDto = new BattlefieldDto();
            foreach (var permanent in battlefield.Permanents)
            {
                var permanentDto = new PermanentDto();
                permanentDto.IsTapped = permanent.IsTapped;
                permanentDto.OracleId = permanent.OracleId;

                battlefieldDto.Permanents.Add(permanentDto);
            }
            return battlefieldDto;
        }

        private HandDto MapHandOwnView(Hand hand)
        {
            var handDto = new HandDto();
            foreach (var card in hand.Cards)
            {
                var cardDto = new CardDto();
                cardDto.IsRevealed = card.IsRevealed;
                cardDto.OracleId = card.OracleId;

                handDto.Cards.Add(cardDto);
            }
            return handDto;
        }

        private HandDto MapHandStrangerView(Hand hand)
        {
            var handDto = new HandDto();
            foreach (var card in hand.Cards)
            {
                var cardDto = new CardDto();
                cardDto.IsRevealed = false;

                handDto.Cards.Add(cardDto);
            }
            return handDto;
        }

        private PlayerDto MapForPlayerStrangerView(Player player)
        {
            var playerDto = new PlayerDto();
            playerDto.Battlefield = MapBattlefield(player.Battlefield);
            playerDto.Hand = MapHandStrangerView(player.Hand);

            return playerDto;
        }
    }
}
