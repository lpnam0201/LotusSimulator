using LotusSimulator.Entities.Players;

namespace LotusSimulator.Entities.Zones
{
    public class Exile
    {
        public Player Player { get; set; }
        public IList<LotusSimulator.Entities.Card.Card> Cards { get; set; }
    }
}
