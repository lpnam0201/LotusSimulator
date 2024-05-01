using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.DependencyInjection
{
    public interface IGame : IDisposable
    {
        Game Game { get; }
        GameWindow Window { get; }

        event EventHandler<EventArgs> Exiting;

        void Run();
        void Exit();
    }
}
