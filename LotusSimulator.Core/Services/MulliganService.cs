using LotusSimulator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class MulliganService
    {
        private LibraryService _libraryService;

        public MulliganService(LibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        public async Task Mulligan(Game game)
        {

        }

        public void Mulligan(Game game, string connectionId)
        {
            var player = game.PlayerIds[connectionId];

            player.Library.Cards.AddRange(player.Hand.Cards);
            player.Hand.Cards.Clear();
            _libraryService.Shuffle(player.Library);
        }
    }
}
