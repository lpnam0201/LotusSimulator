using LotusSimulator.Contract.Constants;
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
        public string OracleId { get; set; }
        public bool IsRevealed { get; set; }
        public string Id { get; set; }
        public bool IsTapped { get; set; }
        public List<ObjectType> Types { get; set; } = new List<ObjectType>();
        public List<PlayabilityDto> Playabilities { get; set; } = new List<PlayabilityDto>();

        public int Index { get; set; }
    }
}
