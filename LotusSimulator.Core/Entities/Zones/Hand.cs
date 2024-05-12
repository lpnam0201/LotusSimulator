using LotusSimulator.Core.Entities.Players;

namespace LotusSimulator.Core.Entities.Zones
{
    public class Hand
    {
        public Player Player { get; set; }
        public IList<Card.Card> Cards { get; set; } = new List<Card.Card>();
    }
}
