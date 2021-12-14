using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Day13.Models;

namespace Day13
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Day 13!");
            
            var url = "https://adventofcode.com/2021/day/13/input";
            var rawData = await AdventHttpClient.getInputDataFromUrl(url);
            var tidyData = TidyData(rawData);
            
            // var testRawData = "6,10\n0,14\n9,10\n0,3\n10,4\n4,11\n6,0\n6,12\n4,1\n0,13\n10,12\n3,4\n3,0\n8,4\n1,10\n2,14\n8,10\n9,0\n\nfold along y=7\nfold along x=5";
            // var testTidyData = TidyData(testRawData);
            // testTidyData.Fold(testTidyData.FoldInstructions[0]);
            
            // tidyData.Fold(tidyData.FoldInstructions[0]);
            // Console.WriteLine(tidyData.Grid.Aggregate(0, (total, row)=>total+row.Count(x=>x>0)));
            
            tidyData.DoAllFolds();
            tidyData.Grid.ForEach(row=> Console.WriteLine(row.Aggregate("",(str, i)=>
            {
                if (i == 0) return str + " ";
                return str + i;
            })));
        }

        private static D13InputData TidyData(string rawData)
        {
            var splitData = rawData.DelimitByBlankLines().ToList();
            var dots = splitData[0].DelimitByCrLf().Select(s => s.DelimitByComma().Select(int.Parse).ToList()).ToList();

            var numberOfRows = dots.Max(x=>x[1]);
            var numberOfColumns = dots.Max(x=>x[0]);
            var grid = new List<List<int>>();
            for (int y = 0; y <= numberOfRows; y++)
            {
                var row = new List<int>();
                for (int x = 0; x <= numberOfColumns; x++)
                {
                    row.Add(0);
                }
                grid.Add(row);
            }
            
            dots.ForEach(d=>grid[d[1]][d[0]]=1);
            
            var instructionData = splitData[1].DelimitByCrLf().Select(x=>x.Split("fold along ", StringSplitOptions.RemoveEmptyEntries)[0].Split("=").ToList())
                .ToList();
            var instructions = instructionData.Select(x => new Instruction(char.Parse(x[0]), int.Parse(x[1]))).ToList();
            return new D13InputData(grid, instructions);
        }
    }
}