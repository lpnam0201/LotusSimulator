using LotusSimulator.Core.Entities.Card;
using LotusSimulator.Core.Entities.Turn;
using LotusSimulator.Core.Entities.Zones;
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
        public async Task Tap(List<Permanent> permanents)
        {
            var tappablePermanent = permanents.Where(x => x.IsTapped);

            foreach (var permanent in tappablePermanent)
            {
                var isContinue = await ProcessTapReplacementEffects(permanent);
                if (!isContinue)
                {
                    return;
                }

                await ProcessTappedHooks(permanent);
            }
        }

        public async Task Untap(List<Permanent> permanents)
        {
            var untappablePermanent = permanents.Where(x => x.IsTapped);

            foreach (var permanent in untappablePermanent)
            {
                var isContinue = await ProcessUntapReplacementEffects(permanent);
                if (!isContinue)
                {
                    return;
                }

                await ProcessUntappedHooks(permanent);
            }
            
        }

        public async Task Untap(Permanent permanent)
        {
            if (permanent.IsTapped)
            {
                var isContinue = await ProcessUntapReplacementEffects(permanent);
                if (!isContinue)
                {
                    return;
                }

                await ProcessUntappedHooks(permanent);
            }
        }

        public async Task EntersBattlefield(List<Permanent> permanents, Battlefield battlefield)
        {
            foreach (var permanent in permanents)
            {
                // add hooks
                battlefield.Add(permanent);
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

        private async Task ProcessTappedHooks(Permanent permanent)
        {
            var game = permanent.Owner.Game;
            var matched = game.HookCollection.PermanentTapped
                .Select(x => x.IsMatch(permanent));
            if (matched.Count() == 0)
            {
                return;
            }

            foreach (var hook in game.HookCollection.PermanentTapped)
            {
                await hook.Run(permanent);
            }
        }

        private async Task<bool> ProcessUntapReplacementEffects(Permanent permanent)
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

        private async Task<bool> ProcessTapReplacementEffects(Permanent permanent)
        {
            var game = permanent.Owner.Game;

            var isContinue = true;
            var matched = game.ReplacementEffectCollection.PermanentTapReplacementEffects
                .Select(x => x.IsMatch(permanent));

            if (matched.Count() == 0)
            {
                return true;
            }

            // TODO pick replacement effect here
            foreach (var replacementEffect in game.ReplacementEffectCollection.PermanentTapReplacementEffects)
            {
                await replacementEffect.Execute(permanent);
            }

            return false;
        }
    }
}
