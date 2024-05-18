using LotusSimulator.Core.Entities.Turn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class StepRunnerFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDictionary<Type, Type> _stepTypeAndStepRunnerDictionary = new Dictionary<Type, Type>
        {
            {typeof(UntapStep), typeof(UntapStepRunner)},
            {typeof(UpkeepStep), typeof(UpkeepStepRunner)},
            {typeof(DrawStep), typeof(DrawStepRunner)},
        };

        public StepRunnerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IStepRunner CreateStepRunner(Type stepType)
        {
            var stepRunnerType = _stepTypeAndStepRunnerDictionary[stepType];
            var stepRunnerInstance = (IStepRunner)_serviceProvider.GetService(stepRunnerType);

            return stepRunnerInstance;
        }
    }
}
