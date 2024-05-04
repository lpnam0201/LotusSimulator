using LotusSimulator.Client.Layout;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddGameConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<IGame, LotusSimulatorGame>();
            services.AddSingleton<LayoutManager>();
            services.AddSingleton<TwoPlayersLayout>();
            
        }
    }
}
