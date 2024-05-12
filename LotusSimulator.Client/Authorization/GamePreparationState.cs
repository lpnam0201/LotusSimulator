using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Authorization
{
    public class GamePreparationState
    {
        public IList<OpponentIdentity> Opponents { get; set; } = new List<OpponentIdentity>();
        public PlayerIdentity Player { get; set; }
        public string GameId { get; set; }
        public object GlobalInstances { get; internal set; }
    }
}
