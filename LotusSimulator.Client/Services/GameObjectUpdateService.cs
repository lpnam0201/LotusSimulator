using LotusSimulator.Client.Models;
using LotusSimulator.Contract.Constants;
using LotusSimulator.Contract.MessageOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Services
{
    public class GameObjectUpdateService
    {
        public void MoveGameObject(GameChangeZoneCollectionDto gameChangeZoneCollection)
        {
            var from = gameChangeZoneCollection.From;
            var to = gameChangeZoneCollection.To;
            var srcZone = DetermineZone(from.PlayerId, from.Zone.Value);
            var destZone = DetermineZone(to.PlayerId, to.Zone.Value);

            var gameObject = GlobalInstances.GameDisplayModel.GetGameObject(to.Object.Id);
            if (gameObject == null)
            {
                gameObject = GlobalInstances.DisplayModelMapper.MapGameObject(to.Object);
            }

            srcZone.Remove(from.Object.Id);
            destZone.Add(gameObject);
        }

        private IZoneModifier DetermineZone(string playerId, GameObjectZone zone)
        {
            var player = GlobalInstances.GameDisplayModel.GetPlayer(playerId);

            switch (zone)
            {
                case GameObjectZone.Hand:
                    return player.Hand;
                case GameObjectZone.Library:
                    return player.Library;
                case GameObjectZone.Battlefield:
                    return player.Battlefield;
                case GameObjectZone.Graveyard:
                    return player.Graveyard;
                case GameObjectZone.Exile:
                    return player.Exile;
                default:
                    return null;
            }
        }

        public void RemoveGameObject()
        {

        }

        //public GameObjectDisplayModel FindGameObject(string playerId, int page, int index, DisplayZone displayZone)
        //{
        //    var gameObjectDisplayModel = GlobalInstances.GameDisplayModel.Players
        //        .SelectMany(x => x.Pages)
        //        .Where(x => x.Index == page)
        //        .SelectMany(x => x.Models)
        //        .Where(x => x.Index == index && x.z == displayZone)
        //        .FirstOrDefault();

        //    return gameObjectDisplayModel;
        //}
    }
}
