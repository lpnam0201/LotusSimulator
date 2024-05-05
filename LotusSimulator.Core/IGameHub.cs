using LotusSimulator.Contract.MessageOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core
{
    public interface ISendGameState
    {
        Task SendGameStates(GameStateCollectionDto gameStateCollection);
    }
}
