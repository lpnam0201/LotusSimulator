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

        public void AssignPlayerToGame(string connectionId)
        {
            if (GameManagers.Count == 0)
            {
                var gameManager = (GameManager)_serviceProvider.GetService(typeof(GameManager));
                GameManagers.Add(gameManager);
            }

            var gameManager = GameManagers.First();
            gameManager.
        }
    }
}
