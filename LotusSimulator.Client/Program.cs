using LotusSimulator.Client.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace LotusSimulator.Client
{
    public static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            new LotusSimulatorGame().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //    .ConfigureServices((hostContext, services) =>
        //    {
        //        services.AddHostedService<HostedService>();
        //        services.AddGameConfiguration();
        //    });
    }
}

