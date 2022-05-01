using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotdammsugare_Sawubona_Claes_R
{
    public class MoveInstruction
    {
        public Direction Direction { get; set; }
        public int NumberOfSteps { get; set; }

        public MoveInstruction(Direction direction, int numberOfSteps)
        {
            Direction = direction;
            NumberOfSteps = numberOfSteps;
        }
    }
}
