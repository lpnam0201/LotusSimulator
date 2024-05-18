using LotusSimulator.Core.Entities.Turn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class UpkeepStepRunner : IStepRunner
    {
        private readonly PriorityService _priorityService;

        public UpkeepStepRunner(PriorityService priorityService)
        {
            _priorityService = priorityService;
        }

        public async Task Run(Step step)
        {
            var activePlayer = step.Phase.Turn.Player;
            await _priorityService.GrantPriority(activePlayer);
        }
    }
}
