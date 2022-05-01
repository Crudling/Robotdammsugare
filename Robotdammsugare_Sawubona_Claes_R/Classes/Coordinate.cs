using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotdammsugare_Sawubona_Claes_R
{
    public class Coordinate
    {
        public int XValue { get; set; }
        public int YValue { get; set; }

        public Coordinate(int xValue, int yValue)
        {
            XValue = xValue;
            YValue = yValue;
        }

        public Coordinate()
        {
        }
    }
}
