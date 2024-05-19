
namespace LotusSimulator.Core.Entities.Zones
{
    public class Command : ICardZone
    {
        public IList<Card.Card> Commanders { get; set; } = new List<Card.Card>();

        public void Add(Card.Card card)
        {
            Commanders.Add(card);
        }

        public void Remove(Card.Card card)
        {
            Commanders.Remove(card);
        }
    }
}
