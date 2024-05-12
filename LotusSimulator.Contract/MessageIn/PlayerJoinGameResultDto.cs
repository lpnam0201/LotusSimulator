using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.MessageIn
{
    public class PlayerJoinGameResultDto
    {
        public string AccessToken { get; set; }
        public int Slot { get; set; }
        public string GameId { get; set; }
    }
}
