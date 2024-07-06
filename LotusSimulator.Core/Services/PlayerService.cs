using LotusSimulator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class PlayerService
    {
        public async Task InitializePlayers(Game game)
        {
            foreach (var player in game.Players)
            {
                player.LifeTotal = 20;
            }
        }
    }
}
