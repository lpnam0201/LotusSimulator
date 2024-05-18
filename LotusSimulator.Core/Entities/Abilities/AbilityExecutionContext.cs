using LotusSimulator.Core.Entities.Card;
using LotusSimulator.Core.Entities.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Entities.Abilities
{
    public class AbilityExecutionContext
    {
        public Card.Card Card { get; set; }

        public Permanent Permanent { get; set; }

        public Player Player { get; set; }
    }
}
