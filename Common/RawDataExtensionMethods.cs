using System;
using System.Collections.Generic;
using System.Linq;
using Common.Models;

namespace Common
{
    public static class RawDataExtensionMethods
    {
        public static List<int> ParseListInt(this string data)
        {
            var delimiters = new[] {'\r', '\n'};
            return data.Split(delimiters)
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(int.Parse)
                .ToList();
        }
        
        public static List<DirectionalInstruction> ParseListDirectionalInstruction(this string data)
        {
            var delimiters = new[] {'\r', '\n'};
            return data.Split(delimiters)
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(s => s.Split(' '))
                .Select(l =>
                {
                    var direction = Enum.Parse<Direction>(l[0].ToTitleCase());
                    var value = Int32.Parse(l[1]);
                    return new DirectionalInstruction(direction, value);
                })
                .ToList();
        }
        
        private static string ToTitleCase(this string str)
        {
            var cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            return cultureInfo.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}