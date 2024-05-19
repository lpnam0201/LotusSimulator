using LotusSimulator.Contract.Constants;
using LotusSimulator.Core.Entities.Players;

namespace LotusSimulator.Core.Entities.Zones
{
    public class Library : ICardZone
    {
        public Player Player { get; set; }
        public List<Card.Card> Cards { get; set; } = new List<Card.Card>();
        public GameObjectZone Zone => GameObjectZone.Library;

        public void Add(Card.Card card)
        {
            Cards.Add(card);
        }

        public void Remove(Card.Card card)
        {
            Cards.Remove(card);
        }

        public bool HasCard(Card.Card card)
        {
            return Cards.Contains(card);
        }
    }
}
