using LotusSimulator.Contract.Constants;
using LotusSimulator.Contract.MessageOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Entities.Zones
{
    public interface ICardZone
    {
        GameObjectZone Zone { get; }
        void Add(Card.Card card);
        void Remove(Card.Card card);
    }
}
