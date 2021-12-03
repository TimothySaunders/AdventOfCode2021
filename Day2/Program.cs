using System;
using System.Threading.Tasks;
using Common;

namespace Day2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Day2!");
            
            var url = "https://adventofcode.com/2021/day/2/input";
            var rawData = await AdventHttpClient.getInputDataFromUrl(url);
            var sanitisedData = rawData.ParseListDirectionalInstruction();
            
            Console.WriteLine(D2P1.GetFinalPositionTimesDepth(sanitisedData));
            
            Console.WriteLine(D2P2.GetFinalPositionTimesDepth(sanitisedData));

        }
    }
}