namespace Day4.Models
{
    public class RowCell
    {
        public int Value { get; set; }
        public bool HasBeenCalled { get; set; }

        public RowCell(int value)
        {
            Value = value;
            HasBeenCalled = false;
        }
    }
}