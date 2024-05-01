namespace LotusSimulator.Core.Entities
{
    public struct MtgNumber
    {
        private int _internalValue;

        public MtgNumber(int value)
        {
            _internalValue = value;
        }

        public static implicit operator MtgNumber(int i) => new MtgNumber(i);

    }
}
