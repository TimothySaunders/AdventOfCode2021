using System.Collections.Generic;
using System.Linq;

namespace Day10.Models
{
    public class Chunk
    {
        private Dictionary<char, char> CharMap = new()
        {
            {'(', ')'}, {'[', ']'}, {'{', '}'}, {'<', '>'}
        };
        
        public List<char> FullChunk { get; set; } = new List<char>();
        public List<char> UnclosedChars { get; set; } = new List<char>();
        public bool isComplete => UnclosedChars.Count == 0;
        public bool isCorrupted = false;
        
        public Chunk(char startingChar)
        {
            FullChunk.Add(startingChar);
            UnclosedChars.Add(startingChar);
        }

        public void ConsiderNewCharacter(char ch)
        {
            FullChunk.Add(ch);
            // if opening char
            if (CharMap.Keys.Contains(ch))
            {
                UnclosedChars.Add(ch);
                return;
            }

            // if closing char 
            // check if closes the most recent open bracket
            if (CharMap[UnclosedChars[^1]] == ch)
            {
                UnclosedChars.RemoveAt(UnclosedChars.Count - 1);
            }
            else
            {
                isCorrupted = true;
            }
        }

        public List<char> AutoComplete()
        {
            var list = new List<char>();
            for (int i = UnclosedChars.Count-1; i >= 0; i--)
            {
                list.Add(CharMap[UnclosedChars[i]]);
            }

            return list;
        }
    }
}