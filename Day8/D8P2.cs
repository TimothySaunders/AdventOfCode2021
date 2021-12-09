using System.Collections.Generic;
using System.Data;
using System.Linq;
using Day8.Models;

namespace Day8
{
    public static class D8P2
    {
        public static int CalculateSumOutputNumbers(List<Day8InputSingle> data)
        {
            data.ForEach(d => d.Solve());
            
            var listOutputsAsInts = data.Select(d=>
            {
                var multiplyer = 10000;
                return d.OutputDigits.Aggregate(0, (total, digit) =>
                {
                    multiplyer /= 10;
                    return total += (multiplyer * digit.Value);
                });
            }).ToList();
            return listOutputsAsInts.Aggregate(0, (total, output) => total += output);
        }
    }
}