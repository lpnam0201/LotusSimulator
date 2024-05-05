using LotusSimulator.Managers;

namespace LotusSimulator
{
    public class GameContainer
    {
        public IList<GameManager> GameManagers { get; set; } = new List<GameManager>();
    }
}
