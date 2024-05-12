using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Authorization
{
    public class GamePreparationState
    {
        public IList<Opponent> Opponents { get; set; } = new List<Opponent>();
        public Player Player { get; set; }
    }
}
