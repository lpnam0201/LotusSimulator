using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Entities.Playability
{
    public static class PlayabilityExtensions
    {
        public static void AddIfNotSame(this IList<Playability> playabilities, Playability playability)
        {
            if (playability == null)
            {
                return;
            }

            if (playabilities.Any(x => x.IsSame(playability)))
            {
                return;
            }

            playabilities.Add(playability);
        }
    }
}
