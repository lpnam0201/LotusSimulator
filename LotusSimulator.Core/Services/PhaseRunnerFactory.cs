using LotusSimulator.Core.Entities.Turn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class PhaseRunnerFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDictionary<Type, Type> _phaseTypeAndPhaseRunnerDictionary = new Dictionary<Type, Type>
        {
            {typeof(BeginningPhase), typeof(BeginningPhaseRunner) }
        };

        public PhaseRunnerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPhaseRunner CreatePhaseRunner(Type phaseType)
        {
            var phaseRunnerType = _phaseTypeAndPhaseRunnerDictionary[phaseType];
            var phaseRunnerInstance = (IPhaseRunner)_serviceProvider.GetService(phaseRunnerType);

            return phaseRunnerInstance;
        }
    }
}
