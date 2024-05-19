namespace LotusSimulator.Contract.MessageOut
{
    public class GameStateDto
    {
        public string PriorityHolder { get; set; }
        public IList<PlayerDto> Players { get; set; }
        public IList<string> TurnOrderConnectionIds { get; set; }

        public LibraryDto GetLibrary(string id)
        {
            return GetPlayer(id).Library;
        }

        public GraveyardDto GetGraveyard(string id)
        {
            return GetPlayer(id).Graveyard;
        }

        public ExileDto GetExile(string id)
        {
            return GetPlayer(id).Exile;
        }

        public HandDto GetHand(string id)
        {
            return GetPlayer(id).Hand;
        }

        public PlayerDto GetPlayer(string id)
        {
            return Players.First(x => x.Id == id);
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