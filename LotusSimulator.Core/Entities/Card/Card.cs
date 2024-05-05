using LotusSimulator.Core.Entities.Counters;
using LotusSimulator.Core.Entities.GameObjects;

namespace LotusSimulator.Core.Entities.Card
{
    // Card = card in hand, in lib, in graveyard... (in-game object)
    // Card logic = keep implementation of effects & printed values, to init a Card when it is first put into library as the game begins
    public class Card : GameObject
    {
        public MtgNumber Power { get; set; }
        public MtgNumber Toughness { get; set; }
        public IList<Counter> LoyaltyCounters { get; set; }
        public IList<Counter> Counters { get; set; }
        public bool IsRevealed { get; set; }

        public CardLogic.CardLogic CardLogic { get; set; }

        public void Initialize()
        {
            CardLogic.CopyStatsToCard(this);
        }
    }
}
