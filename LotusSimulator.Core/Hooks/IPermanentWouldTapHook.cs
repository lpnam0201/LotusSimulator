using LotusSimulator.Core.Entities.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Hooks
{
    public interface IPermanentWouldTapHook
    {
        Task<PermanentTapReplacementHookResult> Run(Permanent permanent);
    }
}
