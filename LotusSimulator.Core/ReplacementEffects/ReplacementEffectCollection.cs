using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.ReplacementEffects
{
    public class ReplacementEffectCollection
    {
        public List<IPermanentUntapReplacementEffect> PermanentUntapReplacementEffects { get; set; }
        public List<IPermanentTapReplacementEffect> PermanentTapReplacementEffects { get; set; }
    }
}
