using System.Net;

namespace BoulderCornBreadForWindows.RetrieveData
{
    internal class GetWebs
    {

        // retrieve JSON from some url
        private string GetJsonFromUrl(string urlPath)
        {
            var json = new WebClient().DownloadString(urlPath);
            return json;
        }

        /*
        // parse out JSON to DataGrid
        public JsonData ParseJson(string url)
        {

            url = "http://getsmartschools.org/currentschools.txt";
            
            return JsonData;
        }
         * */
    }

}
