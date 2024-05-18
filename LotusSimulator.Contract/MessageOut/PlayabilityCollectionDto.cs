using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.MessageOut
{
    public class PlayabilityCollectionDto
    {
        public string ConnectionId { get; set; }
        public int Slot { get; set; }
        public List<PlayabilityDto> Playabilities { get; set; }
    }
}
