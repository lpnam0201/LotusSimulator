using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.MessageOut
{
    public class GameStateCollectionDto
    {
        public IDictionary<string, GameStateDto> GameStates = new Dictionary<string, GameStateDto>();
    }
}
