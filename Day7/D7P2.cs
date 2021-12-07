using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    public class D7P2
    {
        public static int CalculateComplicatedMinimumCrabFuelToAlign(List<int> posns)
        {
            int minFuel = int.MaxValue;
            int? minPosition = null;
            for (int i = 0; i <= posns.Max(); i++)
            {
                var fuelRequired = posns.Aggregate(0, (total, posn) => total + GetFuelForMoves(Math.Abs(i - posn)));
                if (fuelRequired < minFuel)
                {
                    minPosition = i;
                    minFuel = fuelRequired;
                }
            }
            Console.WriteLine($"Minimum fuel consumption is {minFuel} at position {minPosition}");
            return minFuel;
        }
        
        private static int GetFuelForMoves(int moves)
        {
            var fuel = 0;
            for (int i = 1; i <= moves; i++)
            {
                fuel += i;
            }

            return fuel;
        }
    }
}