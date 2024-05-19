using LotusSimulator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class StackService
    {
        public async Task ResolveTop(Game game)
        {
            var topStackObject = game.Stack.Pop();

            await topStackObject.Resolver.Resolve(topStackObject.Context);
            game.PassedPrioritiesWithNoAction = 0;
        }
    }
}
