using LotusSimulator.Core.Entities.Turn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class PreCombatMainPhaseRunner : IPhaseRunner
    {
        private readonly PriorityService _priorityService;

        public PreCombatMainPhaseRunner(PriorityService priorityService)
        {
            _priorityService = priorityService;
        }

        public async Task Run(Phase phase)
        {
            var activePlayer = phase.Turn.Player;
            await _priorityService.GrantPriority(activePlayer);
        }
    }
}
