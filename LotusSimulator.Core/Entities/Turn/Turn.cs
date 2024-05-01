using LotusSimulator.Entities.Players;

namespace LotusSimulator.Entities.Turn
{
    public class Turn
    {
        public Player Player { get; set; }

        public IList<Phase> Phases { get; set; } = new List<Phase>();
    }
}
