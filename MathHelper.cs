using System;
using System.Collections.Generic;
using System.Text;

namespace SFML
{
    public static class MathHelper
    {
        public static float NextFloat(this Random rand, float a, float b)
        {
            float value = (float)rand.NextDouble();
            return value * (b - a) + a;
        }

        public static float GetDistance(float x, float y, float ballCenterX, float ballCenterY)
        {
            return (float)Math.Sqrt((x - ballCenterX) * (x - ballCenterX) +
                                     (y - ballCenterY) * (y - ballCenterY));
        }

        public static (float, float) GetMinAndMaxForRectangle(float coordinate, float delta)
        {
            return (coordinate, coordinate+delta);
        }
    }
}
