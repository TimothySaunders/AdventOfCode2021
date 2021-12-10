using System.Collections.Generic;
using System.Linq;
using Common;
using Day9.Models;

namespace Day9
{
    public static class D9
    {
        public static int CalculateSumOfLowPoints(List<List<int>> grid)
        {
            var sumOfRiskLevels = 0;
            foreach (var (row, y) in grid.WithIndex())
            {
                foreach (var (digit, x) in row.WithIndex())
                {
                    var adjacent = FindAdjacent(x, y, grid);
                    if (adjacent.All(a => a.Value > digit)) sumOfRiskLevels += digit + 1;
                }
            }

            return sumOfRiskLevels;
        }

        public static int CalculateProductOfLargestBasins(List<List<int>> grid)
        {
            var lowPoints = new List<Coordinate>();
            foreach (var (row, y) in grid.WithIndex())
            {
                foreach (var (digit, x) in row.WithIndex())
                {
                    var adjacent = FindAdjacent(x, y, grid);
                    if (adjacent.All(a => a.Value > digit))
                    {
                        lowPoints.Add(new Coordinate(x, y, grid[y][x]));
                    }
                }
            }
            
            var basinSizes = lowPoints.Select(lp=> FindBasinSize(lp.X, lp.Y, grid, new List<Coordinate>()).Count).ToList();

            var top3 = basinSizes.OrderByDescending(x=>x).Take(3).ToList();
            return top3.Aggregate(1, (product, value) => product * value);
        }

        private static List<Coordinate> FindAdjacent(int x, int y, List<List<int>> grid)
        {
            var adjacent = new List<Coordinate>();
            
            if (x != 0) adjacent.Add(new Coordinate(x-1, y,grid[y][x-1]));
            if (x != grid[0].Count - 1) adjacent.Add(new Coordinate(x+1, y,grid[y][x+1]));
            if (y != 0) adjacent.Add(new Coordinate(x, y-1,grid[y-1][x]));
            if (y != grid.Count - 1) adjacent.Add(new Coordinate(x, y+1, grid[y+1][x]));

            return adjacent;
        }

        private static List<Coordinate> FindBasinSize(int x, int y, List<List<int>> grid, List<Coordinate> knownCoordinates)
        {
            var basinCoords = knownCoordinates;

            var adjacent = FindAdjacent(x, y, grid);
            var adjacentInBasin = adjacent.Where(a => a.Value < 9).ToList();
            var newAdjacentInBasin = adjacentInBasin.Where(a => !basinCoords.Contains(a, new CoordinateComparer())).ToList();
            if (newAdjacentInBasin.Count == 0) return basinCoords;
            
            basinCoords.AddRange(newAdjacentInBasin);
            newAdjacentInBasin.ForEach(c=>
            {
                var furtherAdjacent = FindBasinSize(c.X, c.Y, grid, basinCoords);
                var newFurtherAdjacent = furtherAdjacent.Where(a => !basinCoords.Contains(a, new CoordinateComparer())).ToList();
                basinCoords.AddRange(newFurtherAdjacent);
            });

            return basinCoords;
        }
        
        
    }
}