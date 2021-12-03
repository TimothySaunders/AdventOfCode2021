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
        public static List<int> ParseListInt(this string data)
        {
            return data.DelimitByCrLf()
                .Select(int.Parse)
                .ToList();
        }
        
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

        private static IEnumerable<string> DelimitByCrLf(this string data)
        {
            var delimiters = new[] {'\r', '\n'};
            return data.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .AsEnumerable();
        }

        private static char[] ParseStringToCharArray(string str)
        {
            var charArray = new char[str.Length];
            for (var i = 0; i < str.Length; i++)
            {
                charArray[i] = str[i];
            }

            return charArray;
        }

        private static List<bool> ParseBinaryCharArrayIntoBoolList(IEnumerable<char> charArray)
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

        private static BitArray ParseBoolListToBitArray(List<bool> boolList)
        {
            var boolArray = new bool[boolList.Count];
            for (var i = 0; i < boolList.Count; i++)
            {
                boolArray[i] = boolList[i];
            }
            return new BitArray(boolArray);
        }
        
        private static string ToTitleCase(this string str)
        {
            var cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            return cultureInfo.TextInfo.ToTitleCase(str.ToLower());
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
    }
}