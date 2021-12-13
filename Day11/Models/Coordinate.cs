using System.Collections.Generic;

namespace Day11.Models
{
    public class Coordinate
    {
        public int X { get; }
        public int Y { get; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class CoordinateComparer : IEqualityComparer<Coordinate>
    {
        public bool Equals(Coordinate a, Coordinate b)
        {
            //If both object refernces are equal then return true
            if (object.ReferenceEquals(a, b))
            {
                return true;
            }

            //If one of the object refernce is null then return false
            if (a is null || b is null)
            {
                return false;
            }

            return a.X == b.X && a.Y == b.Y;
        }

        public int GetHashCode(Coordinate obj)
        {
            //If obj is null then return 0
            if (obj is null)
            {
                return 0;
            }

            int XHashCode = obj.X.GetHashCode();
            int YHashCode = obj.Y.GetHashCode();
            return XHashCode ^ YHashCode;
        }
    }
}