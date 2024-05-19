using LotusSimulator.Core.Entities.Turn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public abstract class BasePhaseRunner
    {
        protected Step GetNextStep(Phase phase)
        {
            var currentStepIdx = phase.Steps.IndexOf(phase.CurrentStep);
            if (currentStepIdx == phase.Steps.Count)
            {
                return null;
            }

            var nextStepId = currentStepIdx + 1;
            return phase.Steps[nextStepId];
        }
    }
}
