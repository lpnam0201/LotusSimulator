using LotusSimulator.Contract.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.MessageOut
{
    public class GameObjectLocationDto
    {
        public GameObjectDto Object { get; set; }
        public GameObjectZone? Zone { get; set; }
        public string PlayerId { get; set; }
    }
}
