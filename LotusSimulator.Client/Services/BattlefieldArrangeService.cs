using LotusSimulator.Client.Models;
using LotusSimulator.Contract.MessageOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Services
{
    public class BattlefieldArrangeService
    {
        public void MoveGameObject(CardChangeZoneDto cardChangeZone)
        {
            var from = cardChangeZone.From;
            
        }

        public void RemoveGameObject()
        {

        }

        public GameObjectDisplayModel FindGameObject(string playerId, int page, int index, DisplayZone displayZone)
        {
            var gameObjectDisplayModel = GlobalInstances.GameDisplayModel.Players
                .SelectMany(x => x.Pages)
                .Where(x => x.Index == page)
                .SelectMany(x => x.Models)
                .Where(x => x.Index == index && x.DisplayZone == displayZone)
                .FirstOrDefault();

            return gameObjectDisplayModel;
        }
    }
}
