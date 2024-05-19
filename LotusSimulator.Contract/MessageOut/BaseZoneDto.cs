using LotusSimulator.Contract.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.MessageOut
{
    public abstract class BaseZoneDto : IZone
    {
        public abstract GameObjectZone Zone { get; }

        public IList<GameObjectDto> GameObjects { get; set; } = new List<GameObjectDto>();
    }
}
