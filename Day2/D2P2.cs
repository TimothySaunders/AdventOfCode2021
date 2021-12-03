using System.Collections.Generic;
using Common.Models;

namespace Day2
{
    public static class D2P2
    {
        public static int GetFinalPositionTimesDepth(List<DirectionalInstruction> directions)
        {
            var finalHorizontal = 0;
            var finalDepth = 0;
            var aim = 0;
            
            foreach (var instruction in directions)
            {
                switch (instruction.Direction)
                {
                    case Direction.Forward:
                        finalHorizontal += instruction.Value;
                        finalDepth += aim * instruction.Value;
                        break;
                    case Direction.Down:
                        aim += instruction.Value;
                        break;
                    case Direction.Up:
                        aim += -instruction.Value;
                        break;
                }
            }
            
            return finalDepth * finalHorizontal;
        }
    }
}