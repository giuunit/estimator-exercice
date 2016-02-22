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
    public class MathHelperTest
    {
        [TestMethod]
        public void GetTotalRepaymentTest()
        {
            var res = MathHelper.GetTotalRepayment(1000, (float)0.05, 120);

            res = Math.Round(res);

            Assert.AreEqual(res, 1647);
        }
    }
}
