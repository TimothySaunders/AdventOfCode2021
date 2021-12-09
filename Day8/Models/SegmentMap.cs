using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Day8.Models
{
    public class SegmentMap
    {
        public bool Solved => SegmentPossibilities.All(comb => comb.Value.Count == 1);
        public Dictionary<char, List<char>> SegmentPossibilities { get; set; }

        public Dictionary<int, List<List<char>>> KnownArrangements { get; set; } = new()
        {
            {2, new List<List<char>>()},
            {3, new List<List<char>>()},
            {4, new List<List<char>>()},
            {5, new List<List<char>>()},
            {6, new List<List<char>>()},
            {7, new List<List<char>>()}
        };
        
        public static readonly Dictionary<List<char>, int> ValidCombinations = new ()
        {
            {new List<char>() {'a', 'b', 'c', 'e', 'f', 'g'},0},
            {new List<char>() {'c', 'f'},1},
            {new List<char>() {'a', 'c', 'd', 'e', 'g'},2},
            {new List<char>() {'a', 'c', 'd', 'f', 'g'},3},
            {new List<char>() {'b', 'c', 'd', 'f'},4},
            {new List<char>() {'a', 'b', 'd', 'f', 'g'},5},
            {new List<char>() {'a', 'b', 'd', 'e', 'f', 'g'},6},
            {new List<char>() {'a', 'c', 'f'},7},
            {new List<char>() {'a', 'b', 'c', 'd', 'e', 'f','g'},8},
            {new List<char>() {'a', 'b', 'c', 'd', 'f', 'g'},9}
        };

        private static readonly List<char> AllChars = new List<char>() {'a', 'b', 'c', 'd', 'e', 'f', 'g'};

        public SegmentMap(Dictionary<char, List<char>>? map)
        {
            if (map != null)
            {
                SegmentPossibilities = new Dictionary<char, List<char>>(map);
            } else
            {
                SegmentPossibilities = new Dictionary<char, List<char>>()
                {
                    {'a', AllChars.Select(x=>x).ToList()},
                    {'b', AllChars.Select(x=>x).ToList()},
                    {'c', AllChars.Select(x=>x).ToList()},
                    {'d', AllChars.Select(x=>x).ToList()},
                    {'e', AllChars.Select(x=>x).ToList()},
                    {'f', AllChars.Select(x=>x).ToList()},
                    {'g', AllChars.Select(x=>x).ToList()}
                };
            }
        }

        public void InferFromDigit(Digit digit)
        {
            // add to list of unique digit sequences by length
            var length = digit.Segments.Count;
            var alreadyExists = KnownArrangements[length].Any(a => 
                !a.Except(digit.Segments).Any() || !digit.Segments.Except(a).Any());
            if (!alreadyExists)
            {
                KnownArrangements[length].Add(digit.Segments);
            }

            switch (digit.Value)
            {
                case 1:
                    ApplyDeduction(new List<char>(){'c', 'f'}, digit.Segments);
                    return; 
                case 4:
                    ApplyDeduction(new List<char>(){'b', 'c','d','f'}, digit.Segments);
                    return; 
                case 7:
                    ApplyDeduction(new List<char>(){'a', 'c', 'f'}, digit.Segments);
                    return; 
                default:
                    return;
            }
        }

        public void InferFromKnownCombinations()
        {
            if (KnownArrangements[2].Count == 1 && KnownArrangements[3].Count == 1)
            {
                var knownA = KnownArrangements[3][0].Except(KnownArrangements[2][0]).ToList();
                ApplyDeduction(new List<char>(){'a'}, knownA);
            }
            
            // compare digits of same segments lengths
            if (KnownArrangements[5].Count == 3)
            {
                var charsNotIn1 = GetCharsNotInSegs(KnownArrangements[5][0]);
                var charsNotIn2 = GetCharsNotInSegs(KnownArrangements[5][1]);
                var charsNotIn3 = GetCharsNotInSegs(KnownArrangements[5][2]);
                var aggCharsNotIn123 = new List<List<char>>() {charsNotIn1, charsNotIn2, charsNotIn3}.SelectMany(x=>x).ToList();
                
                var possibleBE = aggCharsNotIn123.Where(c => aggCharsNotIn123.Count(ch => ch == c) > 1).Distinct().ToList();
                ApplyDeduction(new List<char>(){'b', 'e'}, possibleBE);

                var possibleCF = aggCharsNotIn123.Except(possibleBE).ToList();
                ApplyDeduction(new List<char>(){'c', 'f'}, possibleCF);
            }
            
            if (KnownArrangements[6].Count == 3)
            {
                var charsNotIn1 = GetCharsNotInSegs(KnownArrangements[6][0]);
                var charsNotIn2 = GetCharsNotInSegs(KnownArrangements[6][1]);
                var charsNotIn3 = GetCharsNotInSegs(KnownArrangements[6][2]);
                var aggCharsNotIn123 = new List<List<char>>() {charsNotIn1, charsNotIn2, charsNotIn3}.SelectMany(x=>x).ToList();
                
                var possibleCDE = aggCharsNotIn123.Distinct().ToList();
                ApplyDeduction(new List<char>(){'c', 'd', 'e'}, possibleCDE);
            }
        }
        
        private List<char> GetCharsNotInSegs(List<char> segs)
        {
            var letters = AllChars.Select(c => c).ToList();
            foreach (var ch in segs) letters.Remove(ch);
            return letters;
        }

        private void ApplyDeduction(List<char> possibleStdSegs, List<char> possibleUnStdSegs)
        {
            GetCharsNotInSegs(possibleUnStdSegs).ForEach(c =>
            {
                possibleStdSegs.ForEach(s=>SegmentPossibilities[s].Remove(c));
            });

            var impossibleStdSegs = SegmentMap.AllChars.Where(c => !possibleStdSegs.Contains(c)).ToList();
            possibleUnStdSegs.ForEach(c =>
            {
                impossibleStdSegs.ForEach(s=>SegmentPossibilities[s].Remove(c));
            });
        }
    }
}