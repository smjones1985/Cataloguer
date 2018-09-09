using System;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaloguerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            GoogleSheetsManager googleSheetsManager = new GoogleSheetsManager();
            googleSheetsManager.Test();
        }
    }
}
