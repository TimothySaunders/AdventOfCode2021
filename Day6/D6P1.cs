using System;
using System.Collections.Generic;
using System.Linq;
using Day6.Models;

namespace Day6
{
    public class D6P1
    {
        public static int CalculateNumberAfterXDays(List<string> data, int days)
        {
            var intData = data.Select(int.Parse);
            
            var lanternfish = new List<LanternFish>();
            foreach (var n in intData)
            {
                lanternfish.Add(new LanternFish(n));
            }

            // var startDaysList = "";
            // foreach (var fish in lanternfish)
            // {
            //     startDaysList = startDaysList + fish.DaysUntilReplication + ", ";
            // }
            // Console.WriteLine($"Initial state: {startDaysList}");

            var startTime = DateTime.UtcNow;
            for (var i = 0; i < days; i++)
            {
                Console.WriteLine($"Processing Day {i+1} / {days}");

                var newFishes = lanternfish
                    .AsParallel()
                    .Select(fish => fish.PassDay())
                    .Where(fish => fish != null)
                    .ToList();
                lanternfish.AddRange(newFishes);

                // var daysList = "";
                // foreach (var fish in lanternfish)
                // {
                //     daysList = daysList + fish.DaysUntilReplication + ", ";
                // }
                // Console.WriteLine($"After {i} days: {daysList}");
            }

            var endTime = DateTime.UtcNow;
            Console.WriteLine($"Calculation took  {endTime-startTime}");

            return lanternfish.Count;
        }
    }
}