namespace Common.Models
{
    public class DirectionalInstruction
    {
        public Direction Direction { get; }
        public int Value { get; }

        public DirectionalInstruction(Direction direction, int value)
        {
            Direction = direction;
            Value = value;
        }
    }
}