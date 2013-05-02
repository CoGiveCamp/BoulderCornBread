using System.Net;

namespace BoulderCornBreadForWindows.RetrieveData
{
    public class GetWebs
    {
        public static string UrlPath = "http://getsmartschools.org/currentschools.txt";

        // retrieve JSON from some url
        public static string GetJsonFromUrl()
        {
            var json = new WebClient().DownloadString(UrlPath);
            return json;
        }

       
        // parse out JSON to DataGrid
        public JsonData ParseJsonToJsonDataObj()
        {
            var jsonResult = GetJsonFromUrl();
            var jsonObj = new JsonData();

            if (IsJson(jsonResult))
            {
                foreach (var item in jsonResult)
                {
                    
                }
            }

            
            return jsonObj;
        }


        public static bool IsJson(string input)
        {
            return input.Trim().StartsWith("{") && input.Trim().EndsWith("}");
        }
       
    }

}
