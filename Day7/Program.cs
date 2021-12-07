using System;
using System.Linq;
using System.Threading.Tasks;
using Common;

namespace Day7
{
    class Program
    {
        static async Task  Main(string[] args)
        {
            Console.WriteLine("Day 7!");
            
            var url = "https://adventofcode.com/2021/day/7/input";
            var rawData = await AdventHttpClient.getInputDataFromUrl(url);
            var tidyData = rawData.DelimitByComma().Select(int.Parse).ToList();
            D7P1.CalculateMinimumCrabFuelToAlign(tidyData);
            D7P2.CalculateComplicatedMinimumCrabFuelToAlign(tidyData);
        }
    }
}