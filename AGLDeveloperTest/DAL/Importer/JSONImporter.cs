using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AGLDeveloperTest.DAL.Importer
{
    public class JSONImporter : FileImporter
    {
        private static string URL;
        private static HttpClient httpClient;

        public JSONImporter(string url)
        {
            URL = url;
            httpClient = new HttpClient();
        }

        /// <summary>
        /// Retuns json data in string format.
        /// </summary>
        /// <returns></returns>
        public override string GetData()
        {
            string jsonData = GetJsonData();
            return jsonData;

        }

        /// <summary>
        /// Fetches json data in string format via WebClient request.
        /// </summary>
        /// <returns></returns>
        private string GetJsonData()
        {
            string str = string.Empty;
            if (httpClient != null)
            {
                WebClient client = new WebClient();
                str = client.DownloadString(URL);
            }

            return str;
        }
    }
}