namespace LotusSimulator.Core.Entities.Zones
{
    public class Stack
    {
        public IList<Spell.Spell> Spells { get; set; } = new List<Spell.Spell>();

        public bool IsEmpty()
        {
            return Spells.Count == 0;
        }
    }
}
