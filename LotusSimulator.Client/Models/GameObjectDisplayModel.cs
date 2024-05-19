using LotusSimulator.Contract.MessageOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Models
{
    public class GameObjectDisplayModel
    {
        public GameObjectDto GameObject { get; set; }
        public int Index { get; set; }
        public DisplayZone DisplayZone { get; set; }
    }
}
