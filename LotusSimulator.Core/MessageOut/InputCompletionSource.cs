using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.MessageOut
{
    public class InputCompletionSource<T> : TaskCompletionSource<T>, IInputCompletionSource
    {
        public bool SetResult(object result)
        {
            if (result is T value)
            {
                return TrySetResult(value);
            }

            return false;
        }
    }
}
