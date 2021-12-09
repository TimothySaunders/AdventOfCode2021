using System.Collections.Generic;
using System.Linq;
using Day8.Models;

namespace Day8
{
    public static class D8P1
    {
        public static int CalculateOnesFoursSevensEights(List<Day8InputSingle> data)
        {
            data.ForEach(d => d.Solve());
           return data.Aggregate(0, (total, single) => total += CalculateOnesFoursSevensAndEights(single));
        }
        
         private static int CalculateOnesFoursSevensAndEights(Day8InputSingle data)
        {
            return data.OutputDigits.Count(d => new List<int?>() {1, 4, 7, 8}.Contains(d.Value));
        }
    }
}