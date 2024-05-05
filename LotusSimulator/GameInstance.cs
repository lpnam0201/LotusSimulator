using LotusSimulator.Core.Entities.Players;
using LotusSimulator.Entities;
using LotusSimulator.Managers;

namespace LotusSimulator
{
    public class GameInstance
    {
        public IDictionary<string, Player> PlayerDictionary = new Dictionary<string, Player>();

        public Game Game { get; set; }

        public GameInstance(GameManager gameManager)
        {

        }

        public void Initialize()
        {

        }
    }
}