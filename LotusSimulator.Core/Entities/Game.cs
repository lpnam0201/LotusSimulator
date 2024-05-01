using LotusSimulator.Core.Entities.Event;
using LotusSimulator.Core.Entities.Players;

namespace LotusSimulator.Entities
{
    public class Game
    {
        public Core.Entities.Turn.Turn CurrentTurn { get; set; }

        public Player PriorityHolder { get; set; }

        public Core.Entities.Zones.Stack Stack { get; set; }

        public IList<Player> Players { get; set; }

        public Queue<Event> EventQueue { get; set; }
    }
}
