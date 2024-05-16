using LotusSimulator.Core.Entities.Card;
using LotusSimulator.Core.Entities.Turn;
using LotusSimulator.Core.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class UntapStepRunner : IStepRunner
    {
        private readonly PermanentService _permanentService;

        public UntapStepRunner(PermanentService permanentService)
        {
            _permanentService = permanentService;
        }

        public async Task Run(Step step)
        {
            var player = step.Phase.Turn.Player;
            var permanents = player.Battlefield.Permanents;
            foreach (var permanent in permanents)
            {
                await _permanentService.Untap(permanent);
            }
        }
    }
}
