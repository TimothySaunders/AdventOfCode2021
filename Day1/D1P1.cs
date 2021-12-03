using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Day1
{
    public static class D1P1
    {
        public static int FindTotalIncreases(List<int> data)
        {
            var previousValue = (int?) null;
            var increases = data.Aggregate(0, (total, value) =>
            {
                var newTotal = (value > previousValue) ? total + 1 : total;
                previousValue = value;
                return newTotal;
            });
            return increases;
        }
    }
}