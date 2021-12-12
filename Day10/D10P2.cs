using System.Collections.Generic;
using System.Linq;
using Day10.Models;

namespace Day10
{
    public static class D10P2
    {
        public static long GetTotalAutocompleteScore(List<List<char>> data)
        {
            var incompleteChunks = new List<Chunk>();
            foreach (var row in data)
            {
                var chunks = new List<Chunk>(){new Chunk(row[0])};
                var j = 1;
                while (j < row.Count && !chunks[^1].isCorrupted)
                {
                    if (chunks[^1].isComplete)
                    {
                        chunks.Add(new Chunk(row[j]));
                    }
                    else
                    {
                        chunks[^1].ConsiderNewCharacter(row[j]);
                        if (j == row.Count-1 && !chunks[^1].isComplete) incompleteChunks.Add(chunks[^1]);
                    }
                    j++;
                }
            }

            var chunkEndings = incompleteChunks.Select(ic => ic.AutoComplete()).ToList();

            return GetScoreFromIncompleteChunks(chunkEndings);
        }

        private static long GetScoreFromIncompleteChunks(List<List<char>> chunkEndings)
        {
            List<long> listOfScores = chunkEndings.Select(ending =>
            {
                return ending.Aggregate((long)0, (endingTotal, ch) =>
                {
                    return ch switch
                    {
                        ')' => endingTotal * 5 + 1,
                        ']' => endingTotal * 5 + 2,
                        '}' => endingTotal * 5 + 3,
                        '>' => endingTotal * 5 + 4,
                        _ => endingTotal
                    };
                });
            }).ToList();

            return listOfScores.OrderBy(x => x).ToList()[(listOfScores.Count-1) / 2];
        }
    }
}