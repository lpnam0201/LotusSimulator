using LotusSimulator.Entities.GameObjects;
using LotusSimulator.Entities.Players;

namespace LotusSimulator.Entities.Card
{
    public class Permanent : GameObject
    {
        public Card Card { get; set; }

        public bool IsToken { get; set; }

        public Player Owner { get; set; }

        public Guid GameId { get; set; }
    }
}
