using LotusSimulator.Core.Entities.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Hooks
{
    public interface IPermanentUntappedHook
    {
        bool IsMatch(Permanent permanent);
        Task Run(Permanent permanent);
    }
}
