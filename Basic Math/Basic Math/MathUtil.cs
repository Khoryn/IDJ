using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Math
{
    class MathUtil
    {
        public static float Sum(float n1, float n2)
        {
            float result = n1 + n2;
            return result = (float)Math.Round(result, 2);
        }

        public static float Subtract(float n1, float n2)
        {
            float result = n1 - n2;
            return result = (float)Math.Round(result, 2);
        }

        public static float Multiply(float n1, float n2)
        {
            float result = n1 * n2;
            return result = (float)Math.Round(result, 2);
        }

        public static float Divide(float n1, float n2)
        {
            float result = n1 / n2;
            return result = (float)Math.Round(result, 2);
        }

        public static float Percentage(float n1, float n2)
        {
            float result = n1/100 * n2;
            return result = (float)Math.Round(result,2);
        }
    }
}
