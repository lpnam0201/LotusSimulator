using LotusSimulator.Core.Entities.Event;
using LotusSimulator.Core.Entities.Players;

namespace LotusSimulator.Entities
{
    public class Game
    {
        public IDictionary<int, Player> PlayerSlots { get; set; } = new Dictionary<int, Player>
        {
            {0, null},
            {1, null}
        };

        public IDictionary<string, Player> PlayerIds { get; set; } = new Dictionary<string, Player>();

        public Core.Entities.Turn.Turn CurrentTurn { get; set; }

        public Player PriorityHolder { get; set; }

        public Core.Entities.Zones.Stack Stack { get; set; }

        public IList<Player> Players { get; set; } = new List<Player>();

        public Queue<Event> EventQueue { get; set; }

        public Player PlayerGoFirst { get; set; }

        // chat
    }
}
