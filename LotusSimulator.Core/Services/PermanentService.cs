using LotusSimulator.Core.Entities.Card;
using LotusSimulator.Core.Entities.Turn;
using LotusSimulator.Core.Hooks;
using LotusSimulator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class PermanentService
    {
        public async Task Untap(List<Permanent> permanents)
        {
            var untappablePermanent

            foreach (var permanent in permanents)
            {
                if (permanent.IsTapped)
                {
                    var isContinue = await ProcessReplacementEffects(permanent);
                    if (!isContinue)
                    {
                        return;
                    }

                    await ProcessUntappedHooks(permanent);
                }
            }
            
        }

        public async Task Untap(Permanent permanent)
        {
            if (permanent.IsTapped)
            {
                var isContinue = await ProcessReplacementEffects(permanent);
                if (!isContinue)
                {
                    return;
                }

                await ProcessUntappedHooks(permanent);
            }
        }

        private async Task ProcessUntappedHooks(Permanent permanent)
        {
            var game = permanent.Owner.Game;
            var matched = game.HookCollection.PermanentUntapped
                .Select(x => x.IsMatch(permanent));
            if (matched.Count() == 0)
            {
                return;
            }

            foreach (var hook in game.HookCollection.PermanentUntapped)
            {
                await hook.Run(permanent);
            }
        }

        private async Task<bool> ProcessReplacementEffects(Permanent permanent)
        {
            var game = permanent.Owner.Game;

            var isContinue = true;
            var matched = game.ReplacementEffectCollection.PermanentUntapReplacementEffects
                .Select(x => x.IsMatch(permanent));

            if (matched.Count() == 0)
            {
                return true;
            }

            // TODO pick replacement effect here
            foreach (var replacementEffect in game.ReplacementEffectCollection.PermanentUntapReplacementEffects)
            {
                await replacementEffect.Execute(permanent);
            }

            return false;
        }

        // Write picker for multiple replacement effect
    }
}
