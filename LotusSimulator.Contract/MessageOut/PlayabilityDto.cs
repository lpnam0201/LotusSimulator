using LotusSimulator.Contract.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.MessageOut
{
    public class PlayabilityDto
    {
        public string ObjectId { get; set; }
        public PlayabilityType Type { get; set; }
        public string Text { get; set; }
        
    }
}
