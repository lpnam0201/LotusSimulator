using LotusSimulator.Core.Entities.Turn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class BeginningPhaseRunner : BasePhaseRunner, IPhaseRunner
    {
        private readonly StepRunnerFactory _stepRunnerFactory;

        public BeginningPhaseRunner(StepRunnerFactory stepRunnerFactory)
        {
            _stepRunnerFactory = stepRunnerFactory;
        }

        public async Task Run(Phase phase)
        {
            phase.CurrentStep = GetNextStep(phase);
            var stepRunner = _stepRunnerFactory.CreateStepRunner(phase.CurrentStep.GetType());
            await stepRunner.Run(phase.CurrentStep);
        }
    }
}
