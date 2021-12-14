using System.Collections.Generic;

namespace Day13.Models
{
    public class D13InputData
    {
        public List<List<int>> Grid { get; set; }
        public List<Instruction> FoldInstructions { get; set; }

        public D13InputData(List<List<int>> grid, List<Instruction> foldInstructions)
        {
            Grid = grid;
            FoldInstructions = foldInstructions;
        }

        public void DoAllFolds()
        {
            FoldInstructions.ForEach(Fold);
        }

        public void Fold(Instruction instruction)
        {
            var newGrid = new List<List<int>>();

            var newYMax = (instruction.Axis == 'y') ? instruction.RowOrColumn : Grid.Count;
            var newXMax = (instruction.Axis == 'x') ? instruction.RowOrColumn : Grid[0].Count;
            
            for (int y = 0; y < newYMax; y++)
            {
                var row = new List<int>();
                for (int x = 0; x < newXMax; x++)
                {
                    row.Add(Grid[y][x]);
                }
                newGrid.Add(row);
            }
            
            var foldedYmin = (instruction.Axis == 'y') ? instruction.RowOrColumn+1 : 0;
            var foldedXmin = (instruction.Axis == 'x') ? instruction.RowOrColumn+1 : 0;

            for (int y = foldedYmin; y < Grid.Count; y++)
            {
                for (int x = foldedXmin; x < Grid[0].Count; x++)
                {
                    if (instruction.Axis == 'x' && newGrid[y][instruction.RowOrColumn - (x - instruction.RowOrColumn)] == 0) newGrid[y][instruction.RowOrColumn - (x - instruction.RowOrColumn)] += Grid[y][x];
                    if (instruction.Axis == 'y' && newGrid[instruction.RowOrColumn - (y - instruction.RowOrColumn)][x] == 0) newGrid[instruction.RowOrColumn - (y - instruction.RowOrColumn)][x] += Grid[y][x];
                }
            }

            Grid = newGrid;
        }
    }
}