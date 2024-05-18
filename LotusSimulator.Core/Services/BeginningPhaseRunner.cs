using LotusSimulator.Core.Entities.Turn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class BeginningPhaseRunner : IPhaseRunner
    {
        private readonly StepRunnerFactory _stepRunnerFactory;

        public BeginningPhaseRunner(StepRunnerFactory stepRunnerFactory)
        {
            _stepRunnerFactory = stepRunnerFactory;
        }

        public async Task Run(Phase phase)
        {
            foreach (var step in phase.Steps)
            {
                phase.CurrentStep = step;
                var stepRunner = _stepRunnerFactory.CreateStepRunner(step.GetType());
                await stepRunner.Run(step);
            }
        }
    }
}
