using LotusSimulator.Contract.MessageOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.MessageIn
{
    public class PlayerInputDto
    {
        public string GameId { get; set; }
        public PlayabilityDto Playability { get; set; }
    }
}
