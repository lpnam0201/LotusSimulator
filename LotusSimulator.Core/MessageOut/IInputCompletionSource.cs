using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.MessageOut
{
    public interface IInputCompletionSource
    {
        bool SetResult(object result);
    }
}
