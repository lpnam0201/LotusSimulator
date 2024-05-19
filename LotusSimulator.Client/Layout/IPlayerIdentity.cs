using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Layout
{
    public interface IPlayerIdentity
    {
        string ConnectionId { get; set; }
    }
}
