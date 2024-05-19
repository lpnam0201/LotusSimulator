using LotusSimulator.Client.Models;
using LotusSimulator.Contract.Helpers;
using LotusSimulator.Contract.MessageOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Services
{
    public class PlayabilityUpdateService
    {
        public void Update(PlayabilityCollectionDto playabilityCollection)
        {
            foreach (var playability in playabilityCollection.Playabilities)
            {
                var gameObject = GetGameObject(playability.ObjectId);
                gameObject?.Playabilities.AddIfNotExists(playability);
            }
        }

        public GameObjectDisplayModel GetGameObject(string id)
        {
            return GlobalInstances.GameDisplayModel.GetGameObject(id);
        }
    }
}
