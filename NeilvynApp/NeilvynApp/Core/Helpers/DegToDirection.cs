using NeilvynApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeilvynApp.Core.Helpers
{
    public static class DegToDirection
    {
        public static Directions ToDirection(this double angle)
        {
            if(angle != null)
            {
                if (angle == 0)
                {
                    return Directions.N;
                } 
                else if (angle > 0 && angle < 90)
                {
                    return Directions.NE;
                }
                else if (angle == 90)
                {
                    return Directions.E;
                }
                else if (angle > 90 && angle < 180)
                {
                    return Directions.SE;
                }
                else if (angle == 180)
                {
                    return Directions.S;
                }
                else if (angle > 180 && angle < 270)
                {
                    return Directions.SW;
                }
                else if (angle == 270)
                {
                    return Directions.W;
                }
                else if (angle > 270 && angle < 360)
                {
                    return Directions.NW;
                }
            }
            return Directions.Origin;
        }
    }
}
