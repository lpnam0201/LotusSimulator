using LotusSimulator.Contract.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.MessageOut
{
    public class BattlefieldDto : BaseZoneDto
    {
        public override GameObjectZone Zone => GameObjectZone.Battlefield;
    }
}
