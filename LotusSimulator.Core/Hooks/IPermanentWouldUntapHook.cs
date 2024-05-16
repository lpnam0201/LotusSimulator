using LotusSimulator.Core.Entities.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Hooks
{
    public interface IPermanentUntapReplacementHook
    {
        Task<PermanentUntapReplacementHookResult> Run(Permanent permanent);
    }
}
