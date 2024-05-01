namespace LotusSimulator.Core.Entities.Turn
{
    public class Phase
    {
        public Turn Turn { get; set; }
        public IList<Step> Steps { get; set; } = new List<Step>();
    }
}
