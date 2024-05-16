using LotusSimulator.Core.Entities.Event;
using LotusSimulator.Core.Entities.Players;
using LotusSimulator.Core.Entities.Turn;
using LotusSimulator.Core.Hooks;
using LotusSimulator.Core.ReplacementEffects;

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

        public List<Core.Entities.Turn.Turn> PastTurns { get; set; } = new List<Turn>();

        public Core.Entities.Turn.Turn CurrentTurn { get; set; }

        public List<Core.Entities.Turn.Turn> FutureTurns { get; set; } = new List<Turn>();

        public HookCollection HookCollection { get; set; } = new HookCollection();

        public ReplacementEffectCollection ReplacementEffectCollection { get; set; } = new ReplacementEffectCollection();

        public Player PriorityHolder { get; set; }

        public Core.Entities.Zones.Stack Stack { get; set; }

        public IList<Player> Players { get; set; } = new List<Player>();

        public Queue<Event> EventQueue { get; set; }

        public Player PlayerGoFirst { get; set; }

        public string Id { get; set; } = Guid.NewGuid().ToString();

        // chat
    }
}
