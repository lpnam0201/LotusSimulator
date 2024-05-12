using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class RandomService
    {
        public int RandomInt(int maxValue)
        {
            return Random.Shared.Next(maxValue);
        }

        public string RandomCardGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
