using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.MessageIn
{
    public class TestButtonDto : IUserInputDto
    {
        public string GameId { get; set; }
        public Guid Guid { get; set; }
    }
}
