using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Models
{
    public class PageDisplayModel
    {
        public const int Capacity = 7;
        public int Index { get; set; }
        public List<GameObjectDisplayModel> Models { get; set; } = new List<GameObjectDisplayModel>();
    }
}
