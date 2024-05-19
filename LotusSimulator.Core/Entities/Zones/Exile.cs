using LotusSimulator.Contract.Constants;
using LotusSimulator.Core.Entities.Players;

namespace LotusSimulator.Core.Entities.Zones
{
    public class Exile : ICardZone
    {
        public Player Player { get; set; }
        public IList<Card.Card> Cards { get; set; } = new List<Card.Card>();
        public GameObjectZone Zone => GameObjectZone.Exile;

        public void Add(Card.Card card)
        {
            Cards.Add(card);
        }

        public void Remove(Card.Card card)
        {
            Cards.Remove(card);
        }
    }
}
