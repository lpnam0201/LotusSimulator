using LotusSimulator.Core.Entities.Counters;
using LotusSimulator.Core.Entities.GameObjects;
using LotusSimulator.Core.Entities.Players;

namespace LotusSimulator.Core.Entities.Card
{
    public class Permanent : GameObject
    {
        public MtgNumber Power { get; set; }
        public MtgNumber Toughness { get; set; }
        public IList<Counter> LoyaltyCounters { get; set; } = new List<Counter>();
        public IList<Counter> Counters { get; set; } = new List<Counter>();
        public List<Playability.Playability> Playabilities { get; set; } = new List<Playability.Playability>();
        public List<Playability.Playability> GrantedPlayabilities { get; set; } = new List<Playability.Playability>();

        public Card Card { get; set; }

        public bool IsToken { get; set; }

        public bool IsTapped { get; set; }

        public Player Owner { get; set; }
    }
}
