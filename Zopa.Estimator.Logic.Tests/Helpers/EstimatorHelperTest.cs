using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zopa.Estimator.Logic.Helpers;
using Zopa.Estimator.Logic.Models;

namespace Zopa.Estimator.Logic.Tests.Helpers
{
    [TestClass]
    public class EstimatorHelperTest
    {
        [TestMethod]
        public void GetBestRateTest()
        {
            var loan = 1000;
            var marketData = new MarketData()
            {
                Items = new List<MarketDataItem>(){
                    new MarketDataItem(){
                        Name = "test",
                        Rate = 0.07F,
                        Available = 1000

                    },
                     new MarketDataItem(){
                        Name = "testX",
                        Rate = 0.08F,
                        Available = 1000

                    },
                     new MarketDataItem(){
                        Name = "testY",
                        Rate = 0.06F,
                        Available = 1000

                    },
                     new MarketDataItem(){
                        Name = "test2",
                        Rate = 0.09F,
                        Available = 2000
                    },
                     new MarketDataItem(){
                        Name = "test3",
                        Rate = 0.05F,
                        Available = 500
                    },
                }
            };

            var res = EstimatorHelper.GetBestRate(marketData, loan);


        }
    }
}
