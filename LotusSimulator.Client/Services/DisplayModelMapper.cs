using LotusSimulator.Client.Models;
using LotusSimulator.Contract.MessageOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Services
{
    public class DisplayModelMapper
    {
        public GameDisplayModel MapToDisplayModel(GameStateDto gameState)
        {
            var gameDisplayModel = new GameDisplayModel
            {
                PriorityHolder = gameState.PriorityHolder,
                Players = gameState.Players.Select(x => MapPlayer(x)).ToList()
            };

            return gameDisplayModel;
        }

        private PlayerDisplayModel MapPlayer(PlayerDto player)
        {
            return new PlayerDisplayModel
            {
                Id = player.Id,
                LifeTotal = player.LifeTotal,
                Battlefield = MapBattlefield(player.Battlefield),
                Hand = MapHand(player.Hand),
                Graveyard = MapGraveyard(player.Graveyard),
                Library = MapLibrary(player.Library),
                Exile = MapExile(player.Exile),
            };
        }

        private BattlefieldDisplayModel MapBattlefield(BattlefieldDto battlefield)
        {
            var battlefieldDisplayModel = new BattlefieldDisplayModel();

            foreach (var gameObject in battlefield.GameObjects)
            {
                battlefieldDisplayModel.Add(MapGameObject(gameObject));
            }

            return battlefieldDisplayModel;
        }



        private ExileDisplayModel MapExile(ExileDto exile)
        {
            return new ExileDisplayModel
            {
                GameObjects = exile.GameObjects.Select(MapGameObject).ToList()
            };
        }

        private HandDisplayModel MapHand(HandDto hand)
        {
            return new HandDisplayModel
            {
                GameObjects = hand.GameObjects.Select(MapGameObject).ToList()
            };
        }

        private GraveyardDisplayModel MapGraveyard(GraveyardDto graveyard)
        {
            return new GraveyardDisplayModel
            {
                GameObjects = graveyard.GameObjects.Select(MapGameObject).ToList()
            };
        }

        private LibraryDisplayModel MapLibrary(LibraryDto library)
        {
            return new LibraryDisplayModel
            {
                GameObjects = library.GameObjects.Select(MapGameObject).ToList()
            };
        }

        public GameObjectDisplayModel MapGameObject(GameObjectDto gameObject)
        {
            return new GameObjectDisplayModel
            {
                Id = gameObject.Id,
                IsRevealed = gameObject.IsRevealed,
                IsTapped = gameObject.IsTapped,
                OracleId = gameObject.OracleId,
                Types = gameObject.Types,
                Playabilities = gameObject.Playabilities
            };
        }
    }
}
