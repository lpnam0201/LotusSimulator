using LotusSimulator.Contract.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.MessageOut
{
    public class GameChangeZoneCollectionDto
    {
        public GameObjectLocationDto From { get; set; }
        public GameObjectLocationDto To { get; set; }
    }
}
