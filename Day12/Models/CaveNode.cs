using System.Collections.Generic;
using System.Linq;

namespace Day12.Models
{
    public class CaveNode
    {
        public string Name { get; set; }
        public List<CaveNode> ConnectedNodes { get; set; } = new ();
        public bool IsBig => Name.All(char.IsUpper);

        public CaveNode(string name)
        {
            Name = name;
        }
    }
}