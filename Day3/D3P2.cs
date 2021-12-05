using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Day3
{
    public static class D3P2
    {
        public static int GetLifeSupportRating(List<BitArray> data)
        {
            var oxygenGeneratorRating = FindCorrectBitArray(data).ParseInt();
            var co2ScrubberRating = FindCorrectBitArray(data, false).ParseInt();

            return oxygenGeneratorRating * co2ScrubberRating;
        }

        private static BitArray FindCorrectBitArray(IEnumerable<BitArray> data, bool useMostCommon = true)
        {
            var i = 0;
            var reducedList = new List<BitArray>();
            reducedList.AddRange(data.Select(ba => ba));
            
            while (reducedList.Count > 1)
            {
                var ones = reducedList.Count(ba => ba[i]);
                var zeros = reducedList.Count(ba => !ba[i]);
                var bitCriteria = useMostCommon ? ones >= zeros : ones < zeros;

                reducedList = reducedList.Where(ba => ba[i] == bitCriteria).ToList();
                i++;
            }

            return reducedList.First();
        }
    }
}