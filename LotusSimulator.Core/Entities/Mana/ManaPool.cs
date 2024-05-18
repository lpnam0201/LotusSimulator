using LotusSimulator.Core.Entities.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Entities.Mana
{
    public class ManaPool
    {
        public Player Player { get; set; }
        public List<Mana> Mana { get; set; } = new List<Mana>();
    }
}
