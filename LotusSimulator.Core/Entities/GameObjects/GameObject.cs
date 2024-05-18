using LotusSimulator.Core.Entities.Mana;
using LotusSimulator.Core.Entities.Abilities;
using LotusSimulator.Core.Entities.Counters;
using LotusSimulator.Core.Entities.Players;

namespace LotusSimulator.Core.Entities.GameObjects
{
    public class GameObject
    {
        public string Id { get; set; }
        public string OracleId { get; set; }
        public string Name { get; set; }
        public ManaCostCollection ManaCost { get; set; }
        public IList<ObjectColor> Colors { get; set; }
        public IList<ObjectType> Types { get; set; }
        public IList<ObjectSuperType> SuperTypes { get; set; }
        public IList<ObjectSubType> SubTypes { get; set; }
        public IList<Ability> Abilities { get; set; } = new List<Ability>();

        public Player Owner { get; set; }
        public Player Controller { get; set; }
    }
}
