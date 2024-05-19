using LotusSimulator.Contract.Constants;
using LotusSimulator.Core.Entities.Players;

namespace LotusSimulator.Core.Entities.Zones
{
    public class Hand : ICardZone
    {
        public Player Player { get; set; }
        public IList<Card.Card> Cards { get; set; } = new List<Card.Card>();
        public GameObjectZone Zone => GameObjectZone.Hand;

        public void Add(Card.Card card)
        {
            card.CardZone = this;
            Cards.Add(card);
        }

        public void Remove(Card.Card card)
        {
            Cards.Remove(card);
        }
    }
}
