using LotusSimulator.Core.Entities.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.ReplacementEffects
{
    public interface IPermanentTapReplacementEffect
    {
        bool IsMatch(Permanent permanent);
        Task Execute(Permanent permanent);
    }
}
