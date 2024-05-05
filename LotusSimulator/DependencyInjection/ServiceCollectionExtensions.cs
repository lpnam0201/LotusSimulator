using LotusSimulator.Managers;

namespace LotusSimulator.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGameServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<GameContainer>();
            serviceCollection.AddTransient<GameManager>();

            return serviceCollection;
        }
    }
}
