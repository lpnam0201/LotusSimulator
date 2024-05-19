using LotusSimulator.Contract.MessageOut;
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
        public GameStateCollectionDto BuildGameStateCollection(Game game)
        {
            var gameStateCollection = new GameStateCollectionDto();
            foreach (var kvp in game.PlayerIds)
            {
                var connectionId = kvp.Key;
                var gameState = new GameStateDto();
                gameState.Players = new List<PlayerDto>();

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
                    playerDto.Slot = FỉndPlayerSlot(game, player);
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
                    .ToList(),
                Slot = FỉndPlayerSlot(game, player)
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

        private int FỉndPlayerSlot(Game game, Player player)
        {
            var slot = game.PlayerSlots.First(x => x.Value.ConnectionId == player.ConnectionId).Key;
            return slot;
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
                var permanentDto = new PermanentDto();
                permanentDto.IsTapped = permanent.IsTapped;
                permanentDto.OracleId = permanent.OracleId;
                permanent.Id = permanent.Id;

                battlefieldDto.Permanents.Add(permanentDto);
            }
            return battlefieldDto;
        }

        private HandDto MapHandOwnView(Hand hand)
        {
            var handDto = new HandDto();
            handDto.Cards = new List<CardDto>();
            foreach (var card in hand.Cards)
            {
                var cardDto = new CardDto();
                cardDto.IsRevealed = card.IsRevealed;
                cardDto.OracleId = card.OracleId;
                cardDto.Id = card.Id;

                handDto.Cards.Add(cardDto);
            }
            return handDto;
        }

        private HandDto MapHandStrangerView(Hand hand)
        {
            var handDto = new HandDto();
            handDto.Cards = new List<CardDto>();
            foreach (var card in hand.Cards)
            {
                var cardDto = new CardDto();
                cardDto.IsRevealed = false;
                cardDto.OracleId = card.OracleId;
                cardDto.Id = card.Id;

                handDto.Cards.Add(cardDto);
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
            libraryDto.Cards = new List<CardDto>();
            foreach (var card in library.Cards)
            {
                var cardDto = new CardDto();
                cardDto.IsRevealed = false;
                cardDto.Id = card.Id;

                libraryDto.Cards.Add(cardDto);
            }

            return libraryDto;
        }

        private ExileDto MapExile(Exile exile)
        {
            var exileDto = new ExileDto();
            exileDto.Cards = new List<CardDto>();
            foreach (var card in exile.Cards)
            {
                var cardDto = new CardDto();
                cardDto.IsRevealed = false;
                cardDto.Id = card.Id;

                exileDto.Cards.Add(cardDto);
            }

            return exileDto;
        }

        private GraveyardDto MapGraveyard(Graveyard graveyard)
        {
            var graveyardDto = new GraveyardDto();
            graveyardDto.Cards = new List<CardDto>();
            foreach (var card in graveyard.Cards)
            {
                var cardDto = new CardDto();
                cardDto.IsRevealed = false;
                cardDto.Id = card.Id;

                graveyardDto.Cards.Add(cardDto);
            }

            return graveyardDto;
        }
    }
}
