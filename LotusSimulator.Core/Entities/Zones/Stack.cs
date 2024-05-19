using LotusSimulator.Core.Entities.Common;
using LotusSimulator.Core.Entities.Stack;

namespace LotusSimulator.Core.Entities.Zones
{
    public class Stack
    {
        public IList<StackObject> StackObjects { get; set; } = new List<StackObject>();

        public bool IsEmpty()
        {
            return StackObjects.Count == 0;
        }

        public StackObject Pop()
        {
            var topObject = StackObjects.LastOrDefault();
            StackObjects.Remove(topObject);
            return topObject;
        }
    }
}
