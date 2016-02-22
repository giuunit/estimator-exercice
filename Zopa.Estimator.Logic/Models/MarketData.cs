using System.Collections.Generic;
using Zopa.Estimator.Logic.Helpers;
namespace Zopa.Estimator.Logic.Models
{
    public class MarketData : IParsedResult
    {
        public List<MarketDataItem> Items = new List<MarketDataItem>();

        public void Add(MarketDataItem item)
        {
            Items.Add(item);
        }

        public override string ToString()
        {
            var toReturn = "";

            foreach (var item in Items)
            {
                toReturn += item.ToString() + "\n";
            }

            return toReturn;
        }
    }
}
