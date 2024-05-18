using LotusSimulator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Hooks
{
    public class HookCollection
    {
        public Game Game { get; set; }
        public List<IPermanentUntappedHook> PermanentUntapped { get; set; } = new List<IPermanentUntappedHook>();
        public List<IPermanentTappedHook> PermanentTapped { get; set; } = new List<IPermanentTappedHook>();
    }
}
