using System.Collections.Generic;
using System.Linq;
using Day6.Models;

namespace Day6
{
    public static class D6P2
    {
        public static long CalculateNumberAfterXDays(List<string> data, int days)
        {
            var intData = data.Select(int.Parse).ToList();

            var problem = new LanternFishProblem(intData);
            return problem.CalculateDistributionAfterXDays(days);
        }
    }
}