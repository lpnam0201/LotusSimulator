using LotusSimulator.Contract.Constants;
using LotusSimulator.Contract.MessageOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Models
{
    public abstract class BaseZoneDisplayModel : IZone, IZoneModifier
    {
        public abstract GameObjectZone Zone { get; }

        public IList<GameObjectDisplayModel> GameObjects { get; set; } = new List<GameObjectDisplayModel>();

        public void Add(GameObjectDisplayModel gameObjectDisplayModel)
        {
            GameObjects.Add(gameObjectDisplayModel);
        }

        public void Remove(string id)
        {
            var existing = GameObjects.FirstOrDefault(x => x.Id == id);
            GameObjects.Remove(existing);
        }
    }
}
