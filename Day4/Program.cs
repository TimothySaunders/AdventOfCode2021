using System;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Day4.Models;

namespace Day4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Day 4!");
            
            var url = "https://adventofcode.com/2021/day/4/input";
            var rawData = await AdventHttpClient.getInputDataFromUrl(url);
            var sanitisedDataP1 = GetDay4Data(rawData);
            var sanitisedDataP2 = GetDay4Data(rawData);
            
            Console.WriteLine(D4P1.CalculateWinningBoardScore(sanitisedDataP1));
            
            Console.WriteLine(D4P2.CalculateLosingBoardScore(sanitisedDataP2));

            Day4Data GetDay4Data(string data)
            {
                var day4Data = new Day4Data();
                var delimitedData = data.DelimitByBlankLines().ToList();
                day4Data.CalledNumbers = delimitedData[0].DelimitByComma().Select(int.Parse).ToList();
    
                for (var i = 1; i < delimitedData.Count; i++)
                {
                    var listOfIntRows = delimitedData[i].ParseIntMatrixFromStringNumberMatrix();
                    
                    day4Data.BingoCards.Add(new BingoCard(listOfIntRows));
                }
    
                return day4Data;
            }
        }
    }
}