using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Common;
using Day10.Models;

namespace Day10
{
    public static class D10P1
    {
        public static int GetTotalSyntaxErrorScore(List<List<char>> data)
        {
            var corruptedLineChunks = new List<Chunk>();
            foreach (var row in data)
            {
                var chunks = new List<Chunk>(){new Chunk(row[0])};
                var j = 1;
                do
                {
                    if (chunks[^1].isComplete)
                    {
                        chunks.Add(new Chunk(row[j]));
                    }
                    else
                    {
                        chunks[^1].ConsiderNewCharacter(row[j]);
                        if (chunks[^1].isCorrupted) corruptedLineChunks.Add(chunks[^1]);
                    }
                    j++;
                } while (!chunks[^1].isCorrupted && j < row.Count);
            }

            return GetScoreFromCorruptChunks(corruptedLineChunks);
        }

        private static int GetScoreFromCorruptChunks(List<Chunk> corruptedLineChunks)
        {
            return corruptedLineChunks.Aggregate(0, (total, chunk) =>
            {
                return chunk.FullChunk[^1] switch
                {
                    ')' => total + 3,
                    ']' => total + 57,
                    '}' => total + 1197,
                    '>' => total + 25137,
                    _ => total
                };
            });
        }
    }
}