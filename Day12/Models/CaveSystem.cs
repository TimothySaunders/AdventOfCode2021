using System.Collections.Generic;
using System.Linq;

namespace Day12.Models
{
    public class CaveSystem
    {
        public CaveNode Start => Nodes.Single(n => n.Name == "start");
        public CaveNode End => Nodes.Single(n => n.Name == "end");
        public List<CaveNode> Nodes { get; set; }

        public CaveSystem(List<CaveNode> nodes)
        {
            Nodes = nodes;
        }

        public List<List<CaveNode>> FindAllPaths(CaveNode startingNode, List<CaveNode> partialPath, int adventProblemPart)
        {
            var paths = new List<List<CaveNode>>();

            var availableNodes = GetAvailableNodes(adventProblemPart, startingNode, partialPath);
            // return conditions
            // no viable connected nodes left
            if (availableNodes.Count == 0)
            {
                return new List<List<CaveNode>>();
            }
            // reached end
            if (startingNode == End)
            {
                paths.Add(partialPath);
                return paths;
            }
            
            // recurse
            availableNodes.ForEach(n=>
            {
                var newPartialPath = partialPath.Select(x => x).ToList();
                newPartialPath.Add(n);
                paths.AddRange(FindAllPaths(n,newPartialPath, adventProblemPart));
            });
            return paths;
        }

        private List<CaveNode> GetAvailableNodes(int adventProblemPart, CaveNode startingNode, List<CaveNode> partialPath)
        {
            switch (adventProblemPart)
            {
                case 1:
                    return startingNode.ConnectedNodes.Where(cn => partialPath.All(c => cn.Name != c.Name) || cn.IsBig).ToList();
                case 2:
                    var smallCaveVisitedTwice = partialPath.Any(c => partialPath.Count(cn => !cn.IsBig && cn.Name == c.Name) > 1);
                    return startingNode.ConnectedNodes.Where(
                        cn => cn.IsBig || partialPath.All(c => cn.Name != c.Name) || (!smallCaveVisitedTwice && cn.Name is not "start")).ToList();
                default:
                    return new List<CaveNode>();
            }
        }
    }
}