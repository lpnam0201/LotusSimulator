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

            return serviceCollection;
        }
    }
}
