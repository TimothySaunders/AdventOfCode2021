using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;

namespace Day11
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Day 11!");
            
            var url = "https://adventofcode.com/2021/day/11/input";
            var rawData = await AdventHttpClient.getInputDataFromUrl(url);
            var tidyData = TidyData(rawData);

            // var testRawData = "11111\n19991\n19191\n19991\n11111";
            // var testRawData = "5483143223\n2745854711\n5264556173\n6141336146\n6357385478\n4167524645\n2176841721\n6882881134\n4846848554\n5283751526";
            // var testTidyData = TidyData(testRawData);
            // Console.WriteLine(D11P1.CalculateFlashesAfterXSteps(testTidyData,100));
            
            Console.WriteLine(D11.CalculateFlashesAfterXSteps(tidyData,100));
            Console.WriteLine(D11.CalculateFirstSynchronisedFlash(tidyData));
        }

        private static List<List<int>> TidyData(string rawData)
        {
            return rawData.DelimitByCrLf().Select(s => 
                    s.ToCharArray().Select(c => 
                        int.Parse(c.ToString())).ToList())
                .ToList();
        }
    }
}