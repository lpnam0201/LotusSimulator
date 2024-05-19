using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Models
{
    public class PlayerDisplayModel
    {
        public string ConnectionId { get; set; }
        public List<PageDisplayModel> Pages { get; set; } = new List<PageDisplayModel>();
        public int? Page { get; set; }

    }
}
