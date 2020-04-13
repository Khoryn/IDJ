using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planck_Constant
{
    class Calculation
    {
        public static double planckConstant = 6.62606896e-34f;
        public static double pi = 3.1415f;

        public static double ReducedPlanck()
        {
            return planckConstant / (2 * pi);
        }
    }
}
