namespace LotusSimulator.Contract.MessageOut
{
    public class GameStateDto
    {
        public int? PriorityHolder { get; set; } = null;
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

        public CardDto GetCard(string id)
        {
            var cards = Players.SelectMany(x => x.Library.Cards)
                .Concat(Players.SelectMany(x => x.Hand.Cards))
                .Concat(Players.SelectMany(x => x.Graveyard.Cards))
                .Concat(Players.SelectMany(x => x.Exile.Cards));

            return cards.FirstOrDefault(x => x.Id == id);
        }

        public PermanentDto GetPermanent(string id)
        {
            var permanents = Players.SelectMany(x => x.Battlefield.Permanents);

            return permanents.FirstOrDefault(x => x.Id == id);
        }
    }
}