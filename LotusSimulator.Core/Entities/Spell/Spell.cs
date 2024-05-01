using LotusSimulator.Core.Entities.GameObjects;

namespace LotusSimulator.Core.Entities.Spell
{
    public class Spell : GameObject
    {
        public IList<Mana.Mana> ManaSpent { get; set; }
    }
}
