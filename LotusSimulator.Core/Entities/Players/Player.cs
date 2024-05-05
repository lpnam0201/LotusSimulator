using LotusSimulator.Core.Entities.Zones;

namespace LotusSimulator.Core.Entities.Players
{
    public class Player
    {
        public MtgNumber LifeTotal { get; set; }

        public Battlefield Battlefield { get; set; }
        public Graveyard Graveyard { get; set; }
        public Hand Hand { get; set; }
        public Exile Exile { get; set; }
        public Library Library { get; set; }
        public Command Command { get; set; }

        public int LandPlayed { get; set; }
        public int LandPlaysPerTurn { get; set; }
    }
}
