using LotusSimulator.Contract.MessageOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.Helpers
{
    public static class PlayabilityExtensions
    {
        public static void AddIfNotExists(this List<PlayabilityDto> playabilities, PlayabilityDto playability)
        {
            if (playabilities.Any(x => x.IsSame(playability)))
            {
                return;
            }

            playabilities.Add(playability);
        }

        public static bool IsSame(this PlayabilityDto playability, PlayabilityDto other)
        {
            return playability.ObjectId == other.ObjectId
                && playability.Type == other.Type;
        }
    }
}
