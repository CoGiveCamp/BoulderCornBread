using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoulderCornBreadForWindows.RetrieveData;

namespace UnitTestBoulderCornBread
{
    [TestClass]
    public class RetrieveDataTest
    {
        const string UrlPath = "http://echo.jsontest.com/key/value/one/two";

        [TestMethod]
        public void Data_From_Remote_Is_JSON()
        {
            var json = GetWebs.GetJsonFromUrl(UrlPath);
            Assert.IsTrue(GetWebs.IsJson(json));

        }

    }
}
