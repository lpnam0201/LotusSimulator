using LotusSimulator.Entities.Mana;
using LotusSimulator.Entities.Abilities;
using LotusSimulator.Entities.Counters;
using LotusSimulator.Entities.Players;

namespace LotusSimulator.Entities.GameObjects
{
    public class GameObject
    {
        public string Name { get; set; }
        public ManaCost ManaCost { get; set; }
        public IList<ObjectColor> Colors { get; set; }
        public IList<ObjectType> Types { get; set; }
        public IList<ObjectSuperType> SuperTypes { get; set; }
        public IList<ObjectSubType> SubTypes { get; set; }
        public IList<Ability> Abilities { get; set; }
        public MtgNumber Power { get; set; }
        public MtgNumber Toughness { get; set; }
        public IList<Counter> LoyaltyCounters { get; set; }
        public IList<Counter> Counters { get; set; }

        public Player Owner { get; set; }
        public Player Controller { get; set; }
    }
}
