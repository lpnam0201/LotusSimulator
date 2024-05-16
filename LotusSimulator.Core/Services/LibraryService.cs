using LotusSimulator.Core.Entities.Zones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class LibraryService
    {
        public RandomService _randomService;

        public LibraryService(RandomService randomService)
        {
            _randomService = randomService;
        }

        public void Shuffle(Library library)
        {
            var count = library.Cards.Count;
            library.Cards = library.Cards.OrderBy(x => _randomService.RandomInt(count)).ToList();
        }
    }
}
