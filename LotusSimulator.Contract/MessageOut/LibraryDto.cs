using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.MessageOut
{
    public class LibraryDto
    {
        public IList<CardDto> RevealedCards { get; set; } = new List<CardDto>();
        public int Count { get; set; }
    }
}
