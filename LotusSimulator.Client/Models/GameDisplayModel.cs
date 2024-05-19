using LotusSimulator.Contract.MessageOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Models
{
    public class GameDisplayModel
    {
        public string YourConnectionId { get; set; }

        public GameStateDto GameState { get; set; }

        public List<PlayerDisplayModel> Players { get; set; } = new List<PlayerDisplayModel>();
    }
}
