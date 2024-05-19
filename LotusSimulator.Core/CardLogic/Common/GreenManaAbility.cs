using LotusSimulator.Core.Entities.Abilities;
using LotusSimulator.Core.Entities.Common;
using LotusSimulator.Core.Entities.Mana;
using LotusSimulator.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.CardLogic.Common
{
    public class GreenManaAbility : SingleManaAbility
    {
        private readonly PermanentService _permanentService;
        private readonly ManaService _manaService;

        protected override ManaColor ManaColor => ManaColor.Green;

        public GreenManaAbility(PermanentService permanentService,
            ManaService manaService)
        {
            _permanentService = permanentService;
            _manaService = manaService;
        }

        public override async Task Resolve(StackObjectResolvingContext stackObjectResolvingContext)
        {
            var permanent = stackObjectResolvingContext.Permanent;
            var player = stackObjectResolvingContext.Player;

            await _permanentService.Tap(
                new List<Entities.Card.Permanent>
                {
                    permanent
                });

            var mana = await _manaService.CreateMana(ManaColor);
            await _manaService.Add(mana, player);
        }
    }
}
