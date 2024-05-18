using LotusSimulator.Core.MessageOut;
using LotusSimulator.Core.Services;
using LotusSimulator.Entities;
using LotusSimulator.Managers;

namespace LotusSimulator.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGameServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<GameContainer>();
            serviceCollection.AddTransient<GameManager>();
            serviceCollection.AddTransient<GameStateService>();
            serviceCollection.AddTransient<RandomService>();
            serviceCollection.AddTransient<Game>();
            serviceCollection.AddTransient<GameStateMapper>();
            serviceCollection.AddTransient<LibraryService>();
            serviceCollection.AddTransient<MulliganService>();
            serviceCollection.AddTransient<TurnService>();
            serviceCollection.AddTransient<PhaseRunnerFactory>();
            serviceCollection.AddTransient<StepRunnerFactory>();
            serviceCollection.AddTransient<PlayabilityService>();
            serviceCollection.AddTransient<PermanentService>();
            serviceCollection.AddTransient<PriorityService>();
            serviceCollection.AddTransient<ManaService>();
            serviceCollection.AddTransient<BeginningPhaseRunner>();
            serviceCollection.AddTransient<UntapStepRunner>();
            serviceCollection.AddTransient<UpkeepStepRunner>();
            serviceCollection.AddTransient<DrawStepRunner>();
            serviceCollection.AddTransient<PreCombatMainPhaseRunner>();
            

            return serviceCollection;
        }
    }
}
