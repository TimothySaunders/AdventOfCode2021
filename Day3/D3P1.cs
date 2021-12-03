using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Day3
{
    public static class D3P1
    {
        public static decimal GetPowerUsage(List<BitArray> data)
        {
            var gammaRateBitArray = new BitArray(data[0].Length);
            var epsilonBitArray = new BitArray(data[0].Length);
            for (var i = 0; i < data[0].Length; i++)
            {
                var ones = data.Count(ba => ba[i]);
                var zeros = data.Count(ba => !ba[i]);
                gammaRateBitArray[i] = (ones > zeros);
                epsilonBitArray[i] = (ones < zeros);
            }

            var gammaRate = gammaRateBitArray.ParseInt();
            var epsilonRate = epsilonBitArray.ParseInt();

            return gammaRate * epsilonRate;
        }
    }
}