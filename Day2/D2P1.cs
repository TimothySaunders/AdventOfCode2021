using System.Collections.Generic;
using Common.Models;

namespace Day2
{
    public static class D2P1
    {
        public static int GetFinalPositionTimesDepth(List<DirectionalInstruction> directions)
        {
            var finalHorizontal = 0;
            var finalDepth = 0;
            
            foreach (var instruction in directions)
            {
                switch (instruction.Direction)
                {
                    case Direction.Forward:
                        finalHorizontal += instruction.Value;
                        break;
                    case Direction.Down:
                        finalDepth += instruction.Value;
                        break;
                    case Direction.Up:
                        finalDepth += -instruction.Value;
                        break;
                }
            }

            return finalDepth * finalHorizontal;
        }
    }
}