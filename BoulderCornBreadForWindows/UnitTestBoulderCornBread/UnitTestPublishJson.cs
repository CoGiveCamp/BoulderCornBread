using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoulderCornBreadForWindows.Publish;

namespace UnitTestBoulderCornBread
{
    [TestClass]
    public class UnitTestPublishJson
    {
        [TestMethod]
        public void TestMethod1()
        {

            PublishJson publish = new PublishJson();
            
            object json = new object();
            Assert.IsTrue(publish.PublishJsontoFtp(json, "test", ""));



        }
    }
}
