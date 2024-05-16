using LotusSimulator.Core.Entities.Zones;
using LotusSimulator.Entities;

namespace LotusSimulator.Core.Entities.Players
{
    public class Player
    {
        public string ConnectionId { get; set; }
        public MtgNumber LifeTotal { get; set; } = 20;

        public Battlefield Battlefield { get; set; } = new Battlefield();
        public Graveyard Graveyard { get; set; } = new Graveyard();
        public Hand Hand { get; set; } = new Hand();
        public Exile Exile { get; set; } = new Exile();
        public Library Library { get; set; } = new Library();
        public Command Command { get; set; } = new Command();

        public Game Game { get; set; }
        public int LandPlayed { get; set; }
        public int LandPlaysPerTurn { get; set; }
    }
}
