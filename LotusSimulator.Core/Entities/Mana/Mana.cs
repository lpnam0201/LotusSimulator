namespace LotusSimulator.Core.Entities.Mana
{
    public class Mana
    {
        public ManaColor Color { get; set; }
        public bool IsSnow { get; set; }

        public IList<ManaCharacteristic> Characteristics { get; set; } = new List<ManaCharacteristic>();
    }
}
