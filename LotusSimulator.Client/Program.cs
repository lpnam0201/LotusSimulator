using LotusSimulator.Client.Services;
using System;
using System.Threading.Tasks;

namespace LotusSimulator.Client
{
    public static class Program
    {
        [STAThread]
        private static async Task Main(string[] args)
        {
            new LotusSimulatorGame().Run();
            GlobalInstances.ReceiveGameStateService = new GameStateService();
            await GlobalInstances.ReceiveGameStateService.RunAsync();
        }
    }
}

