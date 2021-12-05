using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace Day5.Models
{
    public class CoordinatePair
    {
        public Coord Start { get; set; }
        public Coord End { get; set; }

        public CoordinatePair(Coord start, Coord end)
        {
            Start = start;
            End = end;
        }

        public List<Coord> GetPathCoords(bool includeDiagonals = false)
        {
            var coords = new List<Coord>();
            // diagonal
            if (Start.X != End.X && Start.Y != End.Y)
            {
                if (!includeDiagonals) return coords;
                // assume 45deg only
                var steps = Math.Abs(Start.X - End.X + 1);
                var xGradient = (End.X - Start.X) > 0 ? 1 : -1;
                var yGradient = (End.Y - Start.Y) > 0 ? 1 : -1;
                for (var i = 0; i < steps; i++)
                {
                    var x = Start.X + xGradient * i;
                    var y = Start.Y + yGradient * i;
                    coords.Add(new Coord(x, y));
                }
            }
            // horizontal
            if (Start.Y == End.Y)
            {
                var min = Start.X < End.X ? Start.X : End.X;
                var max = Start.X > End.X ? Start.X : End.X;
                for (var x = min; x <= max; x++)
                {
                    coords.Add(new Coord(x, Start.Y));
                }
            }
            // vertical
            if (Start.X == End.X)
            {
                var min = Start.Y < End.Y ? Start.Y : End.Y;
                var max = Start.Y > End.Y ? Start.Y : End.Y;
                for (var y = min; y <= max; y++)
                {
                    coords.Add(new Coord(Start.X, y));
                }
            }

            return coords;
        }
    }
}