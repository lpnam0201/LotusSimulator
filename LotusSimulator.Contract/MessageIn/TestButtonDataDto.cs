using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.MessageIn
{
    public class TestButtonDataDto : IUserInputDto
    {
        public string GameId { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
