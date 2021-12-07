using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    public static class D7P1
    {
        public static int CalculateMinimumCrabFuelToAlign(List<int> posns)
        {
            int minFuel = int.MaxValue;
            int? minPosition = null;
            for (int i = 0; i <= posns.Max(); i++)
            {
                var fuelRequired = posns.Aggregate(0, (total, posn) => total + Math.Abs(i - posn));
                if (fuelRequired < minFuel)
                {
                    minPosition = i;
                    minFuel = fuelRequired;
                }
            }
            Console.WriteLine($"Minimum fuel consumption is {minFuel} at position {minPosition}");
            return minFuel;
        }
    }
}