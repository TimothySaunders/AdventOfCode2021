using System;
using System.Linq;
using System.Threading.Tasks;
using Common;

namespace Day6
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Day 6!");
            
            var url = "https://adventofcode.com/2021/day/6/input";
            var rawData = await AdventHttpClient.getInputDataFromUrl(url);
            var sanitisedData = rawData.DelimitByComma().ToList();

            // var testData = "3,4,3,1,2".DelimitByComma().ToList();
            // Console.WriteLine(D6P1P2.CalculateNumberAfterXDays(testData, 5));
            
            Console.WriteLine(D6P1P2.CalculateNumberAfterXDays(sanitisedData,256));
        }
    }
}