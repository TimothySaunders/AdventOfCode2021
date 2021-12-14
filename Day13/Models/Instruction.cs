namespace Day13.Models
{
    public class Instruction
    {
        public char Axis { get; set; }
        public int RowOrColumn { get; set; }

        public Instruction(char axis, int rowOrColumn)
        {
            Axis = axis;
            RowOrColumn = rowOrColumn;
        }
    }
}