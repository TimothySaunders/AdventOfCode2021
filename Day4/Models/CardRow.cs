using System.Collections.Generic;
using System.Linq;
using Common.Models;

namespace Day4.Models
{
    public class CardRow
    {
        public List<RowCell> Values { get; set; }

        public bool RowComplete => Values.All(v => v.HasBeenCalled);

        public int Score => Values.Where(v => !v.HasBeenCalled).Sum(v => v.Value);

        public CardRow(IEnumerable<int> numbers)
        {
            Values = numbers.Select(n => new RowCell(n)).ToList();
        }

        public void NewNumberCalled(int number)
        {
            Values.ForEach(c =>
            {
                if (c.Value == number) c.HasBeenCalled = true;
            });
        }
    }
}