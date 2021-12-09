using System;
using System.Collections.Generic;
using System.Linq;

namespace Day8.Models
{
    public class Digit
    {
        public int Value;
        public List<char> Segments {get; set; } = new();
        public SegmentMap Map { get; set; }

        public Digit(string segs, SegmentMap map)
        {
            Map = map;
            foreach (var seg in segs)
            {
                Segments.Add(seg);
            }
        }

        public void GetValueFromMap()
        {
            foreach (var combination in SegmentMap.ValidCombinations)
            {
                var normalisedSegs = MapToStandardSegs(Segments);
                var a = !combination.Key.Except(normalisedSegs).Any();
                var b = !normalisedSegs.Except(combination.Key).Any();
                if (!combination.Key.Except(normalisedSegs).Any() && !normalisedSegs.Except(combination.Key).Any())
                {
                    Value = combination.Value;
                    return;
                }
            }

            throw new Exception($"No Value found for Digit {Segments.Aggregate("", (str, ch) => str + ch.ToString())}");
        }

        private List<char> MapToStandardSegs(List<char> segs)
        {
            
            return segs.Select(c => Map.SegmentPossibilities.Single(p => p.Value.Contains(c))).Select(p=> p.Key).ToList();
        }
    }
    
}