using LotusSimulator.Cards.F;
using LotusSimulator.Cards.L;
using LotusSimulator.Core.CardLogic.Common;
using LotusSimulator.Core.Services;
using LotusSimulator.Entities;
using LotusSimulator.Managers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCardLogic(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<Forest>();
            serviceCollection.AddTransient<GreenManaAbility>();

            serviceCollection.AddTransient<LlanowarElves>();


            return serviceCollection;
        }
    }
}
