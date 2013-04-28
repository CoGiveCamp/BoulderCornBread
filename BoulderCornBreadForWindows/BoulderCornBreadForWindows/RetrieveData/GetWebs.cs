using System.Net;

namespace BoulderCornBreadForWindows.RetrieveData
{
    class GetWebs
    {

        // retrieve JSON from some url
        public string GetJsonFromUrl(string urlPath)
        {
            var json = new WebClient().DownloadString(urlPath);
            return json;
        }

        // parse out JSON to DataGrid
        public void SetDataGridViewJson(string input)
        {
            
        }
    }
}
