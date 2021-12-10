using System.Collections.Generic;

namespace Day9.Models
{
    public class Coordinate
    {
        public int X { get; }
        public int Y { get; }
        public int Value { get; }

        public Coordinate(int x, int y, int value)
        {
            X = x;
            Y = y;
            Value = value;
        }
    }
    
    public class CoordinateComparer : IEqualityComparer<Coordinate>
    {
        public bool Equals(Coordinate a, Coordinate b)
        {
            //If both object refernces are equal then return true
            if(object.ReferenceEquals(a, b))
            {
                return true;
            }
            //If one of the object refernce is null then return false
            if (a is null || b is null)
            {
                return false;
            }
            return a.X == b.X && a.Y == b.Y && a.Value == b.Value;
        }
        
        public int GetHashCode(Coordinate obj)
        {
            //If obj is null then return 0
            if(obj is null)
            {
                return 0;
            }
            int XHashCode = obj.X.GetHashCode();
            int YHashCode = obj.Y.GetHashCode();
            int ValueHashCode = obj.Value.GetHashCode();
            return XHashCode ^ YHashCode ^ ValueHashCode;
        }
    }
}