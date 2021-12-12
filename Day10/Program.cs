using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;

namespace Day10
{
    class Program
    {
        static async Task  Main(string[] args)
        {
            Console.WriteLine("Day 10!");
            
            var url = "https://adventofcode.com/2021/day/10/input";
            var rawData = await AdventHttpClient.getInputDataFromUrl(url);
            var tidyData = TidyData(rawData);

            // var testRawData = "[({(<(())[]>[[{[]{<()<>>\n[(()[<>])]({[<{<<[]>>(\n{([(<{}[<>[]}>{[]{[(<()>" +
            //                   "\n(((({<>}<{<{<>}{[]{[]{}\n[[<[([]))<([[{}[[()]]]\n[{[{({}]{}}([{[{{{}}([]" +
            //                   "\n{<[[]]>}<{[{[{[]{()[[[]\n[<(<(<(<{}))><([]([]()\n<{([([[(<>()){}]>(<<{{" +
            //                   "\n<{([{{}}[<[[[<>{}]]]>[]]";
            // var testTidyData = TidyData(testRawData);
            // Console.WriteLine(D10P1.GetTotalSyntaxErrorScore(testTidyData));
            // Console.WriteLine(D10P2.GetTotalAutocompleteScore(testTidyData));

            Console.WriteLine(D10P1.GetTotalSyntaxErrorScore(tidyData));
            Console.WriteLine(D10P2.GetTotalAutocompleteScore(tidyData));
        }

        private static List<List<char>> TidyData(string data)
        {
            return data.DelimitByCrLf().Select(line => line.ToCharArray().ToList()).ToList();
        }
    }
}