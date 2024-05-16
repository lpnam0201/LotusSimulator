using LotusSimulator.Core.Entities.Players;
using LotusSimulator.Entities;

namespace LotusSimulator.Core.Entities.Turn
{
    public class Turn
    {
        public Player Player { get; set; }

        public IList<Phase> Phases { get; set; } = new List<Phase>();

        public Game Game { get; set; }
    }
}
