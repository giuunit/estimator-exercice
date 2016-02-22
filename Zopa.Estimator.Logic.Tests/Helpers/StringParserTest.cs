using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zopa.Estimator.Logic.Helpers;

namespace Zopa.Estimator.Logic.Tests.Helpers
{
    [TestClass]
    public class StringParserTest
    {
        [TestMethod]
        public void ToMarketDataItemTest()
        {
            var mock = "";
            var res = StringParser.ToMarketDataItem(mock);
            Assert.IsNull(res);

            mock = "test";
            res = StringParser.ToMarketDataItem(mock);
            Assert.IsNull(res);

            mock = "test, test";
            res = StringParser.ToMarketDataItem(mock);
            Assert.IsNull(res);

            mock = "test, 0.015";
            res = StringParser.ToMarketDataItem(mock);
            Assert.IsNull(res);

            mock = "test, 0.015, test";
            res = StringParser.ToMarketDataItem(mock);
            Assert.IsNull(res);

            mock = "test, 0.15, 0.12";
            res = StringParser.ToMarketDataItem(mock);
            Assert.IsNull(res);

            mock = "test, 0.15, 100";
            res = StringParser.ToMarketDataItem(mock);
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Name,"test");
            Assert.AreEqual(res.Rate, (float)0.15);
            Assert.AreEqual(res.Available, 100);

            mock = "test, 0.15, 300, 400";
            res = StringParser.ToMarketDataItem(mock);
            Assert.IsNull(res);
        }

        [TestMethod]
        public void ToMarketDataTest()
        {
            var mock =      " \n" +
                            "test\n" +
                            "test, test\n" +
                            "test, 0.015\n" +
                            "test, 0.015, test\n" +
                            "test, 0.15, 100\n" +
                            "test, 0.15, 300, 400\n";

            var res = StringParser.ToMarketData(mock);

            Assert.IsNotNull(res);
            var item = res.Result.Items.First();

            Assert.IsNotNull(item);

            Assert.AreEqual(item.Name, "test");
            Assert.AreEqual(item.Rate, (float)0.15);
            Assert.AreEqual(item.Available, 100);
        }
    }
}
