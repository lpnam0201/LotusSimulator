using LotusSimulator.Core.Entities.Card;

namespace LotusSimulator.Core.Entities.Zones
{
    public class Battlefield
    {
        public IList<Permanent> Permanents { get; set; } = new List<Permanent>();

        public void Add(Permanent permanent)
        {   
            Permanents.Add(permanent);
        }

        public void Remove(Permanent permanent)
        {
            Permanents.Remove(permanent);
        }
    }
}
