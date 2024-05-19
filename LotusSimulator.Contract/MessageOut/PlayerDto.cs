using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.MessageOut
{
    public class PlayerDto
    {
        public int LifeTotal { get; set; }
        public string Id { get; set; }

        public BattlefieldDto Battlefield { get; set; }
        public GraveyardDto Graveyard { get; set; }
        public HandDto Hand { get; set; }
        public ExileDto Exile { get; set; }
        public LibraryDto Library { get; set; }
    }
}
