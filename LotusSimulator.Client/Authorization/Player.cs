using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Authorization
{
    public class Player
    {
        public string AccessToken { get; set; }
        public string ConnectionId { get; set; }
        public int Slot { get; set; }
        public string Nickname { get; set; }
        public PlayerStatus Status { get; set; }
    }
}
