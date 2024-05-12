namespace LotusSimulator.Contract.MessageOut
{
    public class GameStateDto
    {
        public IList<PlayerDto> Players { get; set; }

        public LibraryDto GetLibrary(int slot)
        {
            return GetPlayer(slot).Library;
        }

        public GraveyardDto GetGraveyard(int slot)
        {
            return GetPlayer(slot).Graveyard;
        }

        public ExileDto GetExile(int slot)
        {
            return GetPlayer(slot).Exile;
        }

        public HandDto GetHand(int slot)
        {
            return GetPlayer(slot).Hand;
        }

        public PlayerDto GetPlayer(int slot)
        {
            return Players.First(x => x.Slot == slot);
        }
    }
}