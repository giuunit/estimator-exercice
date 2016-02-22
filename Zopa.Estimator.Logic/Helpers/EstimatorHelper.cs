using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zopa.Estimator.Logic.Models;

namespace Zopa.Estimator.Logic.Helpers
{
    public static class EstimatorHelper
    {
        public static MarketDataItem GetBestRate(MarketData data, int loan)
        {
            var item = data.Items
                .Where(x => x.Available >= loan)
                .OrderBy(x => x.Rate)
                .FirstOrDefault();

            return item;
        }
    }
}
