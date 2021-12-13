using System.Collections.Generic;
using System.Linq;
using Day12.Models;

namespace Day12
{
    public static class D12P1
    {
        public static List<List<CaveNode>> CalculatePaths(List<List<string>> data)
        {
            // create cave system object
            var nodes = new List<CaveNode>();
            foreach (var nodePair in data)
            {
                foreach (var nodeName in nodePair)
                {
                    if (nodes.All(n => n.Name != nodeName)) nodes.Add(new CaveNode(nodeName));
                }

                nodes.Single(n => n.Name == nodePair[0]).ConnectedNodes.Add(nodes.Single(n=>n.Name==nodePair[1]));
                nodes.Single(n => n.Name == nodePair[1]).ConnectedNodes.Add(nodes.Single(n=>n.Name==nodePair[0]));
            }
            var caveSystem = new CaveSystem(nodes);
            
            // find all paths
            return caveSystem.FindAllPaths(caveSystem.Start, new List<CaveNode>(){caveSystem.Start}, 1);
        }
    }
}