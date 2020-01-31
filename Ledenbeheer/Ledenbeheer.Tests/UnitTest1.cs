using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LedenbeheerDomain.Business;
using System.Collections.Generic;

namespace Ledenbeheer.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLoadLeden()
        {
            Controller c = new Controller();
            Assert.AreEqual(c.GetLeden().Count,5);
        }
        [TestMethod]
        public void TestLoadBijdragen()
        {
            Controller c = new Controller();
            Lid _Mhamad = c.GetLid(1);
            List<Bijdrage> bijdragen = _Mhamad.Bijdragen;
            Assert.AreEqual(bijdragen.Count, 3);
        }

    }
}
