using System.Data;
using Day4.Models;

namespace Day4
{
    public static class D4P1
    {
        public static int? CalculateWinningBoardScore(Day4Data data)
        {
            BingoCard winner = null;
            var i = 0;
            while (winner == null)
            {
                data.BingoCards.ForEach(bc =>
                {
                    bc.NewNumberCalled(data.CalledNumbers[i]);
                    if (bc.IsBingo) {winner = bc;} //assume never two winners on same number being called
                });
                i++;
            }

            return winner.Score;
        }
    }
}