using LotusSimulator.Core.Entities.Card;
using LotusSimulator.Core.Entities.Event;
using LotusSimulator.Core.Entities.Players;
using LotusSimulator.Core.Entities.Turn;
using LotusSimulator.Core.Hooks;
using LotusSimulator.Core.ReplacementEffects;

namespace LotusSimulator.Entities
{
    public class Game
    {
        public IList<string> TurnOrderIds { get; set; } = new List<string>();

        public IDictionary<string, Player> PlayerIds { get; set; } = new Dictionary<string, Player>();

        public List<Core.Entities.Turn.Turn> PastTurns { get; set; } = new List<Turn>();

        public Core.Entities.Turn.Turn CurrentTurn { get; set; }

        public List<Core.Entities.Turn.Turn> FutureTurns { get; set; } = new List<Turn>();

        public HookCollection HookCollection { get; set; } = new HookCollection();

        public ReplacementEffectCollection ReplacementEffectCollection { get; set; } = new ReplacementEffectCollection();

        public Player PriorityHolder { get; set; }

        public int PassedPrioritiesWithNoAction { get; set; }

        public Core.Entities.Zones.Stack Stack { get; set; } = new Core.Entities.Zones.Stack();

        public IList<Player> Players { get; set; } = new List<Player>();

        public Queue<Event> EventQueue { get; set; }

        public Player PlayerGoFirst { get; set; }

        public string Id { get; set; } = Guid.NewGuid().ToString();

        public bool IsManaPaymentRequested(Player player)
        {
            return false;
        }

        // chat
        public Player GetPlayerByConnectionId(string connectionId)
        {
            return Players.FirstOrDefault(x => x.ConnectionId == connectionId);
        }

        public Card FindCard(string id)
        {
            var cards = Players.SelectMany(x => x.Library.Cards)
                .Concat(Players.SelectMany(x => x.Graveyard.Cards))
                .Concat(Players.SelectMany(x => x.Hand.Cards))
                .Concat(Players.SelectMany(x => x.Exile.Cards));

            return cards.FirstOrDefault(x => x.Id == id);
        }

        public Permanent FindPermanent(string id)
        {
            var permanents = Players.SelectMany(x => x.Battlefield.Permanents);

            return permanents.FirstOrDefault(x => x.Id == id);
        }
    }
}
