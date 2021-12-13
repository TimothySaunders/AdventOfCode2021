using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;

namespace Day12
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Day 12!");
            
            var url = "https://adventofcode.com/2021/day/12/input";
            var rawData = await AdventHttpClient.getInputDataFromUrl(url);
            var tidyData = TidyData(rawData);
            
            var testRawData = "start-A\nstart-b\nA-c\nA-b\nb-d\nA-end\nb-end";
            var testTidyData = TidyData(testRawData);
            // Console.WriteLine(D12P2.CalculatePaths(testTidyData).Count);
            
            Console.WriteLine(D12P1.CalculatePaths(tidyData).Count);
            Console.WriteLine(D12P2.CalculatePaths(tidyData).Count);
        }
        
        private static List<List<string>> TidyData(string rawData)
        {
            return rawData.DelimitByCrLf().Select(s =>
                s.DelimitByDash().ToList()).ToList();
        }
    }
}