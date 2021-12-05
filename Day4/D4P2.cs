using System.Collections.Generic;
using System.Linq;
using Day4.Models;

namespace Day4
{
    public static class D4P2
    {
        public static int? CalculateLosingBoardScore(Day4Data data)
        {
            BingoCard loser = null;
            var stillToWin = data.BingoCards.Select(bc => bc).ToList();
            var i = 0;
            while (stillToWin.Count > 0)
            {
                var wonThisRound = new List<BingoCard>();
                stillToWin.ForEach(bc =>
                {
                    bc.NewNumberCalled(data.CalledNumbers[i]);
                    if (bc.IsBingo) wonThisRound.Add(bc);
                    if (stillToWin.Count == 1) loser = bc;
                });
                wonThisRound.ForEach(bc => stillToWin.Remove(bc));
                i++;
            }

            return loser!.Score;
        }
    }
}