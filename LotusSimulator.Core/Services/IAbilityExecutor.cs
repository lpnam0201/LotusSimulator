using LotusSimulator.Core.Entities.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public interface IAbilityExecutor
    {
        Task Execute(Ability ability);
    }
}
