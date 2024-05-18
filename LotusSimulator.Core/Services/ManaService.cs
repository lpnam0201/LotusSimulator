using LotusSimulator.Core.Entities.Mana;
using LotusSimulator.Core.Entities.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class ManaService
    {
        private readonly RandomService _randomService;

        public ManaService(RandomService randomService)
        {
            _randomService = randomService;
        }

        public async Task Add(Mana mana, Player player)
        {
            player.ManaPool.Mana.Add(mana);
        }

        public async Task<Mana> CreateMana(ManaColor manaColor)
        {
            return new Mana
            {
                Id = _randomService.RandomGuid(),
                Color = manaColor
            };
        }

        public async Task EmptyManaPool(Player player)
        {
            player.ManaPool.Mana.Clear();
        }
    }
}
