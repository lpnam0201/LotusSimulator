using LotusSimulator.Core.Entities.Counters;
using LotusSimulator.Core.Entities.GameObjects;
using LotusSimulator.Core.Entities.Zones;

namespace LotusSimulator.Core.Entities.Card
{
    // Card = card in hand, in lib, in graveyard... (in-game object)
    // Card logic = keep implementation of effects & printed values, to init a Card when it is first put into library as the game begins
    public class Card : GameObject
    {
        public MtgNumber Power { get; set; }
        public MtgNumber Toughness { get; set; }
        public IList<Counter> LoyaltyCounters { get; set; }
        public IList<Counter> Counters { get; set; }
        public bool IsRevealed { get; set; }
        public List<Playability.Playability> Playabilities { get; set; } = new List<Playability.Playability>();
        public List<Playability.Playability> GrantedPlayabilities { get; set; } = new List<Playability.Playability>();

        public CardLogic.CardLogic CardLogic { get; set; }
        public ICardZone CardZone { get; set; }

        public void Initialize()
        {
            CardLogic.CopyStatsToCard(this);
        }

        public bool IsLand()
        {
            return Types.Any(x => x == ObjectType.Land);
        }

        public bool IsInstant()
        {
            return Types.Any(x => x == ObjectType.Instant);
        }
    }
}
