using System.Collections.Generic;

namespace Day1
{
    public static class D1P2
    {
        public static int FindRollingIncreasesOfX(List<int> data, int groupSize)
        {
            var rollingSumsOfX = new List<int>();
            for (int i = 0; i <= data.Count-groupSize; i++)
            {
                var groupTotal = data[i] + data[i + 1] + data[i + 2];
                rollingSumsOfX.Add(groupTotal);
            }

            return D1P1.FindTotalIncreases(rollingSumsOfX);
        }
    }
}