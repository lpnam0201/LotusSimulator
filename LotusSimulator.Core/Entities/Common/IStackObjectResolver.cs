using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Entities.Common
{
    public interface IStackObjectResolver
    {
        Task Resolve(StackObjectResolvingContext context);
    }
}
