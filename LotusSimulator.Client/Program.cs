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
            GlobalInstances.GameStateService = new GameStateService();
            new LotusSimulatorGame().Run();
        }
    }
}

