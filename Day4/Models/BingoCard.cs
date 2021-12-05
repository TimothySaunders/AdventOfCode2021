using System.Collections.Generic;
using System.Linq;

namespace Day4.Models
{
    public class BingoCard
    {
        public List<CardRow> Rows { get; set; }
        public bool IsBingo => CheckIfBingo();
        private List<int> CalledNumbers = new List<int>();

        public int? Score => GetScore();

        public BingoCard(List<List<int>> rowNumbers)
        {
            Rows = rowNumbers.Select(r => new CardRow(r)).ToList();
        }

        public void NewNumberCalled(int number)
        {
            CalledNumbers.Add(number);
            Rows.ForEach(r => r.NewNumberCalled(number));
        }

        private int? GetScore()
        {
            if (!IsBingo) return null;
            return CalledNumbers[^1] * Rows.Aggregate(0, (total, row) => total + row.Score);
        }

        private bool CheckIfBingo()
        {
            if (Rows.Any(r => r.RowComplete)) return true;
            for (var i = 0; i < Rows[0].Values.Count; i++)
            {
                if (Rows.All(r => r.Values[i].HasBeenCalled)) return true;
            }

            return false;
        }
    }
}