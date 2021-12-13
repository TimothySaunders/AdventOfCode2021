using System.Collections.Generic;
using System.Linq;
using Day11.Models;

namespace Day11
{
    public static class D11
    {
        public static int CalculateFlashesAfterXSteps(List<List<int>> octopusRows, int steps)
        {
            var totalFlashes = 0;
            var octoRows = octopusRows.Select(r => r).ToList();
            for (int i = 1; i <= steps; i++)
            {
                var incrementedOctos = octoRows.Select(row => row.Select(o => o+1).ToList()).ToList();
                var (postStepOctos, flashes) = IncrementAroundTens(incrementedOctos);
                totalFlashes += flashes.Count;
                octoRows = postStepOctos;
            }

            return totalFlashes;
        }
        
        public static int CalculateFirstSynchronisedFlash(List<List<int>> octopusRows)
        {
            var octoRows = octopusRows.Select(r => r).ToList();
            var octoCount = octoRows.Count * octoRows[0].Count;
            var allFlashing = false;
            var steps = 0;
            do
            {
                steps += 1;
                var incrementedOctos = octoRows.Select(row => row.Select(o => o + 1).ToList()).ToList();
                var (postStepOctos, flashes) = IncrementAroundTens(incrementedOctos);
                if (flashes.Count == octoCount) allFlashing = true;
                octoRows = postStepOctos;
            } while (!allFlashing);

            return steps;
        }

        private static (List<List<int>>, List<Coordinate>) IncrementAroundTens(List<List<int>> octopusRows, List<Coordinate> alreadyFlashedThisStep = null)
        {
            var flashingCoords = new List<Coordinate>();
            // create working copy of starting state
            var octoRowsCopy = octopusRows.Select(or => or.Select(o => o).ToList()).ToList();
            // find 10s and add to list
            flashingCoords.AddRange(FindNewFlashes(octoRowsCopy, flashingCoords.Union(alreadyFlashedThisStep ?? new List<Coordinate>()).ToList()));
            // find adjacent octos and increment copy
            var adjacentOctos = FindAdjacents(flashingCoords, octopusRows);
            // recurse and add result to flash count
            if (adjacentOctos.Count == 0)
            {
                // reset >10s to zero
                for (int y = 0; y < octoRowsCopy.Count; y++)
                {
                    for (int x = 0; x < octoRowsCopy[y].Count; x++)
                    {
                        if (octoRowsCopy[y][x] > 9)
                        {
                            octoRowsCopy[y][x] = 0;
                        }
                    }
                }

                return (octoRowsCopy, flashingCoords);
            }
            else
            {
                adjacentOctos.ForEach(c => octoRowsCopy[c.Y][c.X] = octoRowsCopy[c.Y][c.X] + 1);
                var (finalOctos, secondaryFlashes) = IncrementAroundTens(octoRowsCopy, flashingCoords.Union(alreadyFlashedThisStep ?? new List<Coordinate>()).ToList());
                return (finalOctos, flashingCoords.Union(secondaryFlashes).ToList());
            }
        }

        private static List<Coordinate> FindAdjacents(List<Coordinate> flashingCoords, List<List<int>> octoRows)
        {
            var adjacent = new List<Coordinate>();
            flashingCoords.ForEach(fc =>
            {
                var coordComparer = new CoordinateComparer();
                if (fc.X != 0 && !flashingCoords.Contains(new Coordinate(fc.X-1, fc.Y), coordComparer)) adjacent.Add(new Coordinate(fc.X-1, fc.Y)); //left
                if (fc.X != octoRows[0].Count - 1 && !flashingCoords.Contains(new Coordinate(fc.X+1, fc.Y), coordComparer)) adjacent.Add(new Coordinate(fc.X+1, fc.Y)); //right
                if (fc.Y != 0 && !flashingCoords.Contains(new Coordinate(fc.X, fc.Y-1), coordComparer)) adjacent.Add(new Coordinate(fc.X, fc.Y-1)); //up
                if (fc.Y != octoRows.Count - 1 && !flashingCoords.Contains(new Coordinate(fc.X, fc.Y+1), coordComparer)) adjacent.Add(new Coordinate(fc.X, fc.Y+1)); //down
                if (fc.X != 0 && fc.Y != 0 && !flashingCoords.Contains(new Coordinate(fc.X-1, fc.Y-1), coordComparer)) adjacent.Add(new Coordinate(fc.X-1, fc.Y-1)); //up-left
                if (fc.X != octoRows[0].Count - 1 && fc.Y != 0 && !flashingCoords.Contains(new Coordinate(fc.X+1, fc.Y-1), coordComparer)) adjacent.Add(new Coordinate(fc.X+1, fc.Y-1)); //up-right
                if (fc.Y != octoRows.Count - 1 && fc.X != 0 && !flashingCoords.Contains(new Coordinate(fc.X-1, fc.Y+1), coordComparer)) adjacent.Add(new Coordinate(fc.X-1, fc.Y+1));//down-left
                if (fc.Y != octoRows.Count - 1 && fc.X != octoRows[0].Count - 1 && !flashingCoords.Contains(new Coordinate(fc.X+1, fc.Y+1), coordComparer)) adjacent.Add(new Coordinate(fc.X+1, fc.Y+1)); //down-right
            });
            return adjacent;
        }

        private static List<Coordinate> FindNewFlashes(List<List<int>> octopusRows, List<Coordinate> alreadyFlashedThisStep)
        {
            var flashingCoords = new List<Coordinate>();
            for (int y = 0; y < octopusRows.Count; y++)
            {
                for (int x = 0; x < octopusRows[y].Count; x++)
                {
                    if (octopusRows[y][x] >= 10 && (alreadyFlashedThisStep == null || !alreadyFlashedThisStep.Contains(new Coordinate(x, y), new CoordinateComparer())))
                    {
                        flashingCoords.Add(new Coordinate(x, y));
                    }
                }
            }

            return flashingCoords;
        }
    }
}