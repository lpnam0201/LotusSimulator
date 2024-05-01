using LotusSimulator.Core.Entities.Players;

namespace LotusSimulator.Core.Entities.Zones
{
    public class Library
    {
        public Player Player { get; set; }
        public IList<LotusSimulator.Entities.Card.Card> Cards { get; set; }
    }
}
