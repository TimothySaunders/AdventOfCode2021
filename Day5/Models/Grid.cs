using System;
using System.Collections.Generic;
using System.Linq;

namespace Day5.Models
{
    public class Grid
    {
        private int Rows;
        private int Columns;
        public List<Coord> Coords { get; set; } = new List<Coord>();

        public Grid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            for (var x = 0; x < rows; x++)
            {
                for (var y = 0; y < columns; y++)
                {
                    Coords.Add(new Coord(x, y));
                }
            }
        }

        public void Populate(List<Coord> coords)
        {
            var startDate = DateTime.UtcNow;
            var i = 0;
            Coords.ForEach(c =>
            {
                Console.WriteLine($"Populating {i} of {Coords.Count}");
                var amount = coords.AsParallel().Count(co => c.X == co.X && c.Y == co.Y);
                c.IncrementValue(amount);
                i++;
            });
            var endDate = DateTime.UtcNow;
            var diff = endDate - startDate;
            Console.WriteLine("Populating grid took " + diff);
        }

        public void Visualise()
        {
            for (int i = 0; i < Rows; i++)
            {
                var rowString = string.Join(" ",Coords
                    .Where(c => c.Y == i)
                    .OrderBy(c => c.X)
                    .Select(c => c.Value.ToString()));
                Console.WriteLine(rowString);
            }
        }
    }
}