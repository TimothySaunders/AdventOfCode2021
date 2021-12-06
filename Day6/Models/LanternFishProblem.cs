using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Day6.Models
{
    public class LanternFishProblem
    {
        //day == index
        private List<long> FishCountByDay = new List<long>(){0,0,0,0,0,0,0,0,0};

        public LanternFishProblem(List<int> fishDays)
        {
            for (var i = 0; i < FishCountByDay.Count; i++)
            {
                FishCountByDay[i] += fishDays.Count(fd => fd==i);
            }
        }

        public long CalculateDistributionAfterXDays(int days)
        {
            for (int d = 1; d <= days; d++)
            {
                var newFishCountByDay = new List<long>() {0, 0, 0, 0, 0, 0, 0, 0, 0};
                for (int dayIndex = 0; dayIndex < FishCountByDay.Count; dayIndex++)
                {
                    switch (dayIndex)
                    {
                        case 0:
                            newFishCountByDay[6] += FishCountByDay[0];
                            newFishCountByDay[8] = FishCountByDay[0];
                            break;
                        case 1:
                            newFishCountByDay[0] = FishCountByDay[1];
                            break;
                        case 2:
                            newFishCountByDay[1] = FishCountByDay[2];
                            break;
                        case 3:
                            newFishCountByDay[2] = FishCountByDay[3];
                            break;
                        case 4:
                            newFishCountByDay[3] = FishCountByDay[4];
                            break;
                        case 5:
                            newFishCountByDay[4] = FishCountByDay[5];
                            break;
                        case 6:
                            newFishCountByDay[5] = FishCountByDay[6];
                            break;
                        case 7:
                            newFishCountByDay[6] += FishCountByDay[7];
                            break;
                        case 8:
                            newFishCountByDay[7] = FishCountByDay[8];
                            break;
                    }
                }

                FishCountByDay = newFishCountByDay;
            }

            return FishCountByDay.Aggregate((long)0, (total, day) => total + day);
        }
    }
}