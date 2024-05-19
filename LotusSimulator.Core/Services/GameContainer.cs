using LotusSimulator.Core.Entities;
using LotusSimulator.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class GameContainer
    {
        public IList<GameManager> GameManagers { get; set; } = new List<GameManager>();

        private IServiceProvider _serviceProvider;

        public GameContainer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public AssignPlayerToGameResult AssignPlayerToGame(string connectionId)
        {
            if (GameManagers.Count == 0)
            {
                var newGameManager = (GameManager)_serviceProvider.GetService(typeof(GameManager));
                GameManagers.Add(newGameManager);
            }

            var gameManager = GameManagers.First();
            var gameId = gameManager.GetGameId();
            gameManager.AddPlayerToGame(connectionId);

            return new AssignPlayerToGameResult
            {
                GameId = gameId
            };
        }
    }
}
