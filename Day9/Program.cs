using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;

namespace Day9
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Day 9!");
            
            var url = "https://adventofcode.com/2021/day/9/input";
            var rawData = await AdventHttpClient.getInputDataFromUrl(url);
            var tidyData = TidyData(rawData);

            // var testRawData = "2199943210\n3987894921\n9856789892\n8767896789\n9899965678";
            // var testTidyData = TidyData(testRawData);
            // Console.WriteLine(D9.CalculateSumOfLowPoints(testTidyData));
           // Console.WriteLine(D9.CalculateProductOfLargestBasins(testTidyData));
            
            Console.WriteLine(D9.CalculateSumOfLowPoints(tidyData));
            Console.WriteLine(D9.CalculateProductOfLargestBasins(tidyData));
        }

        private static List<List<int>> TidyData(string data)
        {
            return data.DelimitByCrLf().Select(line => line.ToCharArray()
                    .Select(s => int.Parse(s.ToString())).ToList()).ToList();
        }
    }
}