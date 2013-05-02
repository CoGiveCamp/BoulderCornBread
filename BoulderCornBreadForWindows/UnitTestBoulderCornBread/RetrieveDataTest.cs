using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoulderCornBreadForWindows.RetrieveData;


namespace UnitTestBoulderCornBread
{
    [TestClass]
    public class RetrieveDataTest
    {


        [TestMethod]
        public void Data_From_Remote_Is_JSON()
        {
            var json = GetWebs.GetJsonFromUrl();
            Assert.IsTrue(GetWebs.IsJson(json));

        }

        [TestMethod]
        public void Json_Data_Parses_And_Is_Not_Null()
        {

            var sampleJson = GetWebs.ParseJsonToJsonDataObj();
            Assert.IsNotNull(sampleJson);

        }

    }
}
