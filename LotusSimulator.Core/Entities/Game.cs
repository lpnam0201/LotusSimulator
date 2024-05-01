using LotusSimulator.Entities.Players;

namespace LotusSimulator.Entities
{
    public class Game
    {
        public LotusSimulator.Entities.Turn.Turn CurrentTurn { get; set; }

        public Player PriorityHolder { get; set; }

        public Zones.Stack Stack { get; set; }

        public IList<Player> Players { get; set; }
    }
}
