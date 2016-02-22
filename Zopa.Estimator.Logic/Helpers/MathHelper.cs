using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zopa.Estimator.Logic.Helpers
{
    public static class MathHelper
    {
        public static double GetTotalRepayment(int loan, float rate, int months)
        {            
            return loan * Math.Pow((1 + (rate / 12)), months);
        }
    }
}
