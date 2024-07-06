using LotusSimulator.Contract.MessageOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Models
{
    public class PlayerDisplayModel
    {
        public string Id { get; set; }
        public int LifeTotal { get; set; }
        public LibraryDisplayModel Library { get; set; } = new LibraryDisplayModel();
        public BattlefieldDisplayModel Battlefield { get; set; } = new BattlefieldDisplayModel();
        public GraveyardDisplayModel Graveyard { get; set; } = new GraveyardDisplayModel();
        public HandDisplayModel Hand { get; set; } = new HandDisplayModel();
        public ExileDisplayModel Exile { get; set; } = new ExileDisplayModel();
        public List<PageDisplayModel> Pages { get; set; } = new List<PageDisplayModel>();
        public int? CurrentPage { get; set; }

    }
}
