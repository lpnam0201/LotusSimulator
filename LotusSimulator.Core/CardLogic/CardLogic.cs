using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.CardLogic
{
    public abstract class CardLogic
    {
        public virtual void CopyStatsToCard(Entities.Card.Card card)
        {

        }

        public virtual void Cast(Entities.Card.Card card)
        {

        }

        public virtual void Resolve()
        {

        }
    }
}
