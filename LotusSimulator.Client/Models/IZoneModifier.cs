using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Models
{
    public interface IZoneModifier
    {
        void Add(GameObjectDisplayModel gameObjectDisplayModel);
        void Remove(string id);
    }
}
