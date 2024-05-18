using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.MessageOut
{
    public class PermanentDto
    {
        public string OracleId { get; set; }
        public bool IsTapped { get; set; }
        public string Id { get; set; }
        public List<PlayabilityDto> Playabilities { get; set; } = new List<PlayabilityDto>();
    }
}
