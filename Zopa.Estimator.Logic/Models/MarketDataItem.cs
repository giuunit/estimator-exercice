using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zopa.Estimator.Logic.Helpers;

namespace Zopa.Estimator.Logic.Models
{
    public class MarketDataItem
    {
        public string Name { get; set; }
        public float Rate { get; set; }
        public int Available { get; set; }

        public override string ToString()
        {
            return string.Format("Name : {0}, Rate : {1}, Available : {2}", Name, Rate, Available);
        }
    }
}
