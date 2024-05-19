using LotusSimulator.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Entities.Stack
{
    public class StackObject
    {
        public StackObjectResolvingContext Context { get; set; }
        public IStackObjectResolver Resolver { get; set; }
    }
}
