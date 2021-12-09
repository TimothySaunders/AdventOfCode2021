using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Day8.Models
{
    public class Day8InputSingle
    {
        public List<Digit> InputDigits { get; set; } = new();
        public List<Digit> OutputDigits { get; set; } = new();
        public SegmentMap Map { get; set; }

        public Day8InputSingle(List<string> inputDigitStrings, List<string> outputDigitStrings)
        {
            Map = new SegmentMap(null);
            inputDigitStrings.ForEach(s => InputDigits.Add(new Digit(s, Map)));
            outputDigitStrings.ForEach(s => OutputDigits.Add(new Digit(s, Map)));

            InputDigits.Union(OutputDigits).ToList().ForEach(d => Map.InferFromDigit(d));

        }

        public void Solve()
        {
            foreach (var digit in InputDigits.Union(OutputDigits)) Map.InferFromDigit(digit);
            Map.InferFromKnownCombinations();
            if (!Map.Solved) return;
            foreach (var digit in OutputDigits) digit.GetValueFromMap();
        }
    }
}