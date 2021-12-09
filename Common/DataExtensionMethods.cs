using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Common.Models;

namespace Common
{
    public static class RawDataExtensionMethods
    {
        //Day1
        public static List<int> ParseListIntFromCrList(this string data)
        {
            return data.DelimitByCrLf()
                .Select(int.Parse)
                .ToList();
        }
        
        //Day2
        public static List<DirectionalInstruction> ParseListDirectionalInstruction(this string data)
        {
            return data.DelimitByCrLf()
                .Select(s => s.Split(' '))
                .Select(l =>
                {
                    var direction = Enum.Parse<Direction>(l[0].ToTitleCase());
                    var value = Int32.Parse(l[1]);
                    return new DirectionalInstruction(direction, value);
                })
                .ToList();
        }

        //Day3
        public static List<BitArray> ParseListBitArray(this string data)
        {
            return data.DelimitByCrLf()
                .Select(s =>
                {
                    var charArray = ParseStringToCharArray(s);
                    return ParseBinaryCharArrayIntoBoolList(charArray);
                })
                .Select(ParseBoolListToBitArray)
                .ToList();
        }

        public static IEnumerable<string> DelimitByCrLf(this string data)
        {
            var delimiters = new[] {'\r', '\n'};
            return data.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .AsEnumerable();
        }

        public static IEnumerable<string> DelimitByBlankLines(this string data)
        {
            var delimiter = "\n\n";
            return data.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)
                .AsEnumerable();
        }

        public static IEnumerable<string> DelimitByComma(this string data)
        {
            var delimiter = ',';
            return data.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)
                .AsEnumerable();
        }
        
        public static IEnumerable<string> DelimitBySpace(this string data)
        {
            var delimiter = ' ';
            return data.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)
                .AsEnumerable();
        }
        
        public static IEnumerable<string> DelimitByRightArrow(this string data)
        {
            var delimiter = " -> ";
            return data.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)
                .AsEnumerable();
        }
        
        public static IEnumerable<string> DelimitByBar(this string data)
        {
            var delimiter = " | ";
            return data.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)
                .AsEnumerable();
        }

        public static char[] ParseStringToCharArray(string str)
        {
            var charArray = new char[str.Length];
            for (var i = 0; i < str.Length; i++)
            {
                charArray[i] = str[i];
            }

            return charArray;
        }

        public static List<bool> ParseBinaryCharArrayIntoBoolList(IEnumerable<char> charArray)
        {
            var boolStrings = charArray.Select(c =>
            {
                switch (c.ToString())
                {
                    case "0":
                        return bool.FalseString;
                    case "1":
                        return bool.TrueString;
                    default:
                        throw new FormatException();
                }
            });
            return boolStrings.Select(bool.Parse).ToList();
        }

        public static BitArray ParseBoolListToBitArray(List<bool> boolList)
        {
            var boolArray = new bool[boolList.Count];
            for (var i = 0; i < boolList.Count; i++)
            {
                boolArray[i] = boolList[i];
            }
            return new BitArray(boolArray);
        }
        
        public static List<int> ParseListIntFromSpaceSeparatedList(this string data)
        {
            return data.DelimitBySpace()
                .Select(int.Parse)
                .ToList();
        }

        public static List<List<int>> ParseIntMatrixFromStringNumberMatrix(this string stringNumberMatrix)
        {
            return stringNumberMatrix.DelimitByCrLf()
                .Select(ParseListIntFromSpaceSeparatedList)
                .ToList();
        }
        
        public static int ParseInt(this BitArray bitArray)
        {
            var total = 0;
            for (var i = 0; i < bitArray.Count; i++)
            {
                if (bitArray[i])
                {
                    var reverseIndex = bitArray.Count - 1 - i;
                    total += (int)Math.Pow(2.0, reverseIndex);
                }
            }

            return total;
        }
        
        public static string ToTitleCase(this string str)
        {
            var cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            return cultureInfo.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}