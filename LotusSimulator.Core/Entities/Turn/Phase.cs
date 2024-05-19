namespace LotusSimulator.Core.Entities.Turn
{
    public class Phase
    {
        public bool IsContinueAutomatically { get; set; }
        public Turn Turn { get; set; }
        public Step CurrentStep { get; set; }
        public IList<Step> Steps { get; set; } = new List<Step>();
    }
}
