using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Entities.Mana
{
    public class ManaCostCollection
    {
        public IList<ManaCost> ManaCost { get; set; } = new List<ManaCost>();
    }
}
