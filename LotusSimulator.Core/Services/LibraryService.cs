using LotusSimulator.Core.Entities.Players;
using LotusSimulator.Core.Entities.Zones;
using LotusSimulator.Entities;
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

        public async Task DrawFirstHand(Game game)
        {
            foreach (var player in game.Players)
            {
                for (var i = 0; i < 7; i++)
                {
                    await Draw(player);
                }
            }
        }

        public async Task Draw(Player player)
        {
            var library = player.Library;

            var cardsDrawn = library.Cards.Take(1).ToList();
            foreach (var card in cardsDrawn)
            {
                player.Hand.Cards.Add(card);
            }
            library.Cards = library.Cards.Skip(1).ToList();
        }
    }
}
