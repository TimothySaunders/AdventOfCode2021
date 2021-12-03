using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Common;

namespace Day1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Day1!");
            
            var url = "https://adventofcode.com/2021/day/1/input";
            var rawData = await AdventHttpClient.getInputDataFromUrl(url);
            var sanitisedData = rawData.ParseListInt();

            Console.WriteLine(D1P1.FindTotalIncreases(sanitisedData));

            Console.WriteLine(D1P2.FindRollingIncreasesOfX(sanitisedData, 3));
        }
    }
}