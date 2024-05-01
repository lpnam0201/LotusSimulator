using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Cards.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCardServices(this IServiceCollection services)
        {

            return services;
        }
    }
}
