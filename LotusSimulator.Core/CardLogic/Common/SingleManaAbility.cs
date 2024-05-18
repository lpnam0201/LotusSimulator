using LotusSimulator.Contract.Constants;
using LotusSimulator.Core.Entities.Abilities;
using LotusSimulator.Core.Entities.Mana;
using LotusSimulator.Core.Entities.Playability;
using LotusSimulator.Core.Entities.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.CardLogic.Common
{
    public abstract class SingleManaAbility : Ability
    {
        public override bool IsManaAbility => true;

        protected abstract ManaColor ManaColor { get; }

        public override Playability GetPlayability(Player player)
        {
            return new Playability()
            {
                Location = PlayabilityLocation.Hand,
                PlayableBy = player,
                Text = $"Add {ManaColor}",
                Type = PlayabilityType.Activate
            };
        }
    }
}
