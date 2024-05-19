using LotusSimulator.Contract.Constants;
using LotusSimulator.Contract.MessageOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Models
{
    public class LibraryDisplayModel : BaseZoneDisplayModel
    {
        public override GameObjectZone Zone => GameObjectZone.Library;
    }
}
