using LotusSimulator.Contract.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.MessageIn
{
    public class GamePreparationPlayerStatusDto
    {
        public string Nickname { get; set; }
        public GamePreparationPlayerStatus Status { get; set; }
        public int Slot { get; set; }
    }
}
