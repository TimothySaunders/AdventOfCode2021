using System.Collections.Generic;
using System.Linq;
using Day5.Models;

namespace Day5
{
    public static class D5P1
    {
        public static List<Coord> GetOverlappingPoints(List<CoordinatePair> pairs)
        {
            var allCoords = pairs.SelectMany(p => new List<Coord>() {p.Start, p.End}).ToList();
            var maxX = allCoords.Max(c => c.X);
            var maxY = allCoords.Max(c => c.Y);
            var grid = new Grid(maxX+1, maxY+1);
            var allPairPathCoords = pairs.SelectMany(p => p.GetPathCoords()).ToList();
            grid.Populate(allPairPathCoords);
            //grid.Visualise();

            return grid.Coords.Where(c => c.Value > 1).ToList();
        }
    }
}