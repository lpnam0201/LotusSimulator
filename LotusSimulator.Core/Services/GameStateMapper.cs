using LotusSimulator.Contract.Constants;
using LotusSimulator.Contract.MessageOut;
using LotusSimulator.Core.Entities.Card;
using LotusSimulator.Core.Entities.GameObjects;
using LotusSimulator.Core.Entities.Playability;
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
        public GameChangeZoneCollectionDto BuildCardChangeZoneDto(
            GameObject srcObject,
            GameObjectZone srcZone,
            string srcPlayerId,
            GameObject destObject,
            GameObjectZone destZone,
            string destPlayerId)
        {
            return new GameChangeZoneCollectionDto
            {
                From = new GameObjectLocationDto
                {
                    Object = new GameObjectDto
                    {
                        Id = srcObject.Id,
                        OracleId = srcObject.OracleId,
                        IsRevealed = true,
                        Types = srcObject.Types,
                    },
                    Zone = srcZone,
                    PlayerId = srcPlayerId
                },
                To = new GameObjectLocationDto
                {
                    Object = new GameObjectDto
                    {
                        Id = destObject.Id,
                        OracleId = destObject.OracleId,
                        IsRevealed = true,
                        Types = destObject.Types,
                    },
                    Zone = destZone,
                    PlayerId = destPlayerId
                }
            };
        }

        public GameStateCollectionDto BuildGameStateCollection(Game game)
        {
            var gameStateCollection = new GameStateCollectionDto();
            foreach (var kvp in game.PlayerIds)
            {
                var connectionId = kvp.Key;
                var gameState = new GameStateDto();
                gameState.Players = new List<PlayerDto>();
                gameState.TurnOrderConnectionIds = game.TurnOrderIds;

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
                    playerDto.Id = player.ConnectionId;
                    gameState.Players.Add(playerDto);
                }

                gameStateCollection.GameStates.Add(connectionId, gameState);
            }

            return gameStateCollection;
        }

        public PlayabilityCollectionDto BuildPlayabilityCollectionDto(Game game, string connectionId)
        {
            var player = game.Players.FirstOrDefault(x => x.ConnectionId == connectionId);
            var playabilities = player.Hand.Cards.SelectMany(x => x.Playabilities)
                .Concat(player.Library.Cards.SelectMany(x => x.Playabilities)
                .Concat(player.Graveyard.Cards.SelectMany(x => x.Playabilities)
                .Concat(player.Exile.Cards.SelectMany(x => x.Playabilities)
                .Concat(player.Battlefield.Permanents.SelectMany(x => x.Playabilities)))));

            return new PlayabilityCollectionDto()
            {
                ConnectionId = connectionId,
                Playabilities = playabilities
                    .Select(x => ToPlayabilityDto(x))
                    .ToList()
            };

        }

        private PlayabilityDto ToPlayabilityDto(Playability playability)
        {
            return new PlayabilityDto()
            {
                ObjectId = playability.AssociatedObjectId,
                PlayableByPlayerId = playability.PlayableBy.ConnectionId,
                Text = playability.Text,
                Type = playability.Type
            };
        }

        private PlayerDto MapForPlayerOwnView(Player player)
        {
            var playerDto = new PlayerDto();
            playerDto.Battlefield = MapBattlefield(player.Battlefield);
            playerDto.Hand = MapHandOwnView(player.Hand);
            playerDto.Library = MapLibrary(player.Library);
            playerDto.Exile = MapExile(player.Exile);
            playerDto.Graveyard = MapGraveyard(player.Graveyard);

            return playerDto;
        }

        private BattlefieldDto MapBattlefield(Battlefield battlefield)
        {
            var battlefieldDto = new BattlefieldDto();
            foreach (var permanent in battlefield.Permanents)
            {
                var gameObject = new GameObjectDto();
                gameObject.IsTapped = permanent.IsTapped;
                gameObject.OracleId = permanent.OracleId;
                gameObject.Id = permanent.Id;
                gameObject.Types = permanent.Types;

                battlefieldDto.GameObjects.Add(gameObject);
            }
            return battlefieldDto;
        }

        private HandDto MapHandOwnView(Hand hand)
        {
            var handDto = new HandDto();
            handDto.GameObjects = new List<GameObjectDto>();
            foreach (var card in hand.Cards)
            {
                var gameObjectDto = new CardDto();
                gameObjectDto.IsRevealed = card.IsRevealed;
                gameObjectDto.OracleId = card.OracleId;
                gameObjectDto.Id = card.Id;
                gameObjectDto.Types = card.Types;

                handDto.GameObjects.Add(gameObjectDto);
            }
            return handDto;
        }

        private HandDto MapHandStrangerView(Hand hand)
        {
            var handDto = new HandDto();
            handDto.GameObjects = new List<GameObjectDto>();
            foreach (var card in hand.Cards)
            {
                var gameObjectDto = new CardDto();
                gameObjectDto.IsRevealed = false;
                gameObjectDto.OracleId = card.OracleId;
                gameObjectDto.Id = card.Id;
                gameObjectDto.Types = card.Types;

                handDto.GameObjects.Add(gameObjectDto);
            }
            return handDto;
        }

        private PlayerDto MapForPlayerStrangerView(Player player)
        {
            var playerDto = new PlayerDto();
            playerDto.Battlefield = MapBattlefield(player.Battlefield);
            playerDto.Hand = MapHandStrangerView(player.Hand);
            playerDto.Library = MapLibrary(player.Library);
            playerDto.Exile = MapExile(player.Exile);
            playerDto.Graveyard = MapGraveyard(player.Graveyard);

            return playerDto;
        }

        private LibraryDto MapLibrary(Library library)
        {
            var libraryDto = new LibraryDto();
            libraryDto.GameObjects = new List<GameObjectDto>();
            foreach (var card in library.Cards)
            {
                var gameObjectDto = new GameObjectDto();
                gameObjectDto.IsRevealed = false;
                gameObjectDto.Id = card.Id;
                gameObjectDto.Types = card.Types;

                libraryDto.GameObjects.Add(gameObjectDto);
            }

            return libraryDto;
        }

        private ExileDto MapExile(Exile exile)
        {
            var exileDto = new ExileDto();
            exileDto.GameObjects = new List<GameObjectDto>();
            foreach (var card in exile.Cards)
            {
                var gameObjectDto = new GameObjectDto();
                gameObjectDto.IsRevealed = false;
                gameObjectDto.Id = card.Id;
                gameObjectDto.Types = card.Types;

                exileDto.GameObjects.Add(gameObjectDto);
            }

            return exileDto;
        }

        private GraveyardDto MapGraveyard(Graveyard graveyard)
        {
            var graveyardDto = new GraveyardDto();
            graveyardDto.GameObjects = new List<GameObjectDto>();
            foreach (var card in graveyard.Cards)
            {
                var gameObjectDto = new GameObjectDto();
                gameObjectDto.IsRevealed = false;
                gameObjectDto.Id = card.Id;
                gameObjectDto.Types = card.Types;

                graveyardDto.GameObjects.Add(gameObjectDto);
            }

            return graveyardDto;
        }
    }
}
