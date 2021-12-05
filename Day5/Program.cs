using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using Common;
using Day5.Models;

namespace Day5
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Day5!");
            
            var url = "https://adventofcode.com/2021/day/5/input";
            var rawData = await AdventHttpClient.getInputDataFromUrl(url);
            var sanitisedData = GetDay5Data(rawData);

            // var testRawData =
            //     "0,9 -> 5,9\n8,0 -> 0,8\n9,4 -> 3,4\n2,2 -> 2,1\n7,0 -> 7,4\n6,4 -> 2,0\n0,9 -> 2,9\n3,4 -> 1,4\n0,0 -> 8,8\n5,5 -> 8,2";
            // var testData = GetDay5Data(testRawData);
            //
            // var overlappingPointsWithoutDiagonals = D5P1.GetOverlappingPoints(sanitisedData);
            // Console.WriteLine(overlappingPointsWithoutDiagonals.Count);
            
            var overlappingPointsWithDiagonals = D5P2.GetOverlappingPoints(sanitisedData);
            Console.WriteLine(overlappingPointsWithDiagonals.Count);
        }

        private static List<CoordinatePair> GetDay5Data(string data)
        {
            var delimitedByReturn = data.DelimitByCrLf();
            return delimitedByReturn.Select(ParseStringCoordinatePair).ToList();
        }

        // "xx, yy -> xx,yy"
        public static CoordinatePair ParseStringCoordinatePair(string str)
        {
            //["xx, yy", "xx, yy"]
            var arrowDelimited = str.DelimitByRightArrow();
            //[["xx", "yy"],["xx", "yy"]]
            var commaDelimited = arrowDelimited.Select(s => s.DelimitByComma());
            var coords = commaDelimited.Select(GetCoordinateFromStringList).ToList();
            return new CoordinatePair(coords[0], coords[1]);
        }
        
        private static Coord GetCoordinateFromStringList(IEnumerable<string> stringList)
        {
            var intList = stringList.Select(int.Parse).ToList();
            return new Coord(intList[0], intList[1]);
        }
    }
}