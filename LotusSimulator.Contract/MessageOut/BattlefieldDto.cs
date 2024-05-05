using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.MessageOut
{
    public class BattlefieldDto
    {
        public IList<PermanentDto> Permanents { get; set; } = new List<PermanentDto>();
    }
}
