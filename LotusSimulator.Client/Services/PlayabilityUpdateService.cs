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
                var card = GlobalInstances.GameState.GetCard(playability.ObjectId);
                card?.Playabilities.AddIfNotExists(playability);

                var permanent = GlobalInstances.GameState.GetPermanent(playability.ObjectId);
                permanent?.Playabilities.AddIfNotExists(playability);
            }
        }
    }
}
