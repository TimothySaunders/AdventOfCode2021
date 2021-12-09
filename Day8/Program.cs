using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Day8.Models;

namespace Day8
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Day 8!");
            
            var url = "https://adventofcode.com/2021/day/8/input";
            var rawData = await AdventHttpClient.getInputDataFromUrl(url);
            var tidyData = ParseInput(rawData).ToList();


            // var testRawData = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf";
            // var testTidyData = ParseInput(testRawData).ToList();
            // Console.WriteLine(D8P2.CalculateSumOutputNumbers(testTidyData));


            Console.WriteLine(D8P1.CalculateOnesFoursSevensEights(tidyData));
            Console.WriteLine(D8P2.CalculateSumOutputNumbers(tidyData));
        }

        private static IEnumerable<Day8InputSingle> ParseInput(string data)
        {
            return data.DelimitByCrLf().Select(ParseDay8Single);
        }

        private static Day8InputSingle ParseDay8Single(string data)
        {
            var splitData = data.DelimitByBar().ToList();
            var inputDigits = splitData[0].DelimitBySpace().ToList();
            var outputDigits = splitData[1].DelimitBySpace().ToList();
            return new Day8InputSingle(inputDigits, outputDigits);
        }
    }
}