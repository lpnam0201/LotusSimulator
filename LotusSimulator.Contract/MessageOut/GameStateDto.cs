namespace LotusSimulator.Contract.MessageOut
{
    public class GameStateDto
    {
        public string PriorityHolder { get; set; }
        public IList<PlayerDto> Players { get; set; }
        public IList<string> TurnOrderConnectionIds { get; set; }
    }
}