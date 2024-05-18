using LotusSimulator.Core.Entities.Card;
using LotusSimulator.Core.Entities.Playability;
using LotusSimulator.Core.Entities.Players;
using LotusSimulator.Core.Services;

namespace LotusSimulator.Core.Entities.Abilities
{
    public abstract class Ability
    {
        public string Id { get; } = Guid.NewGuid().ToString();

        public abstract Playability.Playability GetPlayability(Player player);

        public abstract bool IsManaAbility { get; }

        public abstract Task Run(AbilityExecutionContext abilityExecutionContext);
    }
}
