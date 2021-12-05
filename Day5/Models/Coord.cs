namespace Day5.Models
{
    public class Coord
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; } = 0;

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void IncrementValue(int amount = 1)
        {
            Value += amount;
        }
    }
}