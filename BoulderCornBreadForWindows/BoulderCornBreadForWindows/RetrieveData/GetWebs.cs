using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

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
        public static List<JsonData> ParseJsonToJsonDataObj()
        {
            var json = GetJsonFromUrl();

            if (IsJson(json))
            {

                return JsonConvert.DeserializeObject<List<JsonData>>(json);
            }

            throw new Exception("data is empty or does not match object");
        }


        public static bool IsJson(string input)
        {
            return input.Trim().StartsWith("[") && input.Trim().EndsWith("]");
        }
       
    }

}
