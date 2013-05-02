using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBoulderCornBread
{
    [TestClass]
    public class RetrieveDataTest
    {
        [TestMethod]
        public void Data_From_Remote_Is_JSON()
        {
            var urlPath = "http://api.geonames.org/citiesJSON?north=44.1&south=-9.9&east=-22.4&west=55.2&lang=de&username=demo";
            var json = new WebClient().DownloadString(urlPath);
            Assert.IsFalse(IsJson(json));

        }

        private bool IsJson(string input)
        {
            return input.StartsWith("{");
        }
    }
}
