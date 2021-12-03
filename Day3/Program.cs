using System;
using System.Collections;
using System.Threading.Tasks;
using Common;

namespace Day3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Day 3!");
            
            var url = "https://adventofcode.com/2021/day/3/input";
            var rawData = await AdventHttpClient.getInputDataFromUrl(url);
            var sanitisedData = rawData.ParseListBitArray();

            Console.WriteLine(D3P1.GetPowerUsage(sanitisedData));
        }
    }
}