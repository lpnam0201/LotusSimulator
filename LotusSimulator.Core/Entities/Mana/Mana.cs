namespace LotusSimulator.Core.Entities.Mana
{
    public class Mana
    {
        public string Id { get; set; }
        public ManaColor Color { get; set; }
        public bool IsSnow { get; set; }

        // can only be used on creature spells, don't lose as phases and steps ends..etc..
        public IList<ManaCharacteristic> Characteristics { get; set; } = new List<ManaCharacteristic>();
    }
}
