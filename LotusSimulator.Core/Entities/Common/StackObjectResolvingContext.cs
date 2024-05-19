using LotusSimulator.Core.Entities.Card;
using LotusSimulator.Core.Entities.Players;
using LotusSimulator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Entities.Common
{
    public class StackObjectResolvingContext
    {
        public Game Game { get; set; }

        public Card.Card Card { get; set; }

        public Permanent Permanent { get; set; }

        public Player Player { get; set; }
    }
}
