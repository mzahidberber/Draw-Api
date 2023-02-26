using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace Draw.Core.Services
{   public class PointGeo
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
    public class L
    {
        public double length { get; set; }
    }
    public class GeoService
    {
        static string url = "http://127.0.0.1:5001/geo/";
        static HttpClient client = new HttpClient();

        public static async Task<string> Get(string method)
        {
            string serviceUrl = $"{url}{method}";
            using (var r = await client.GetAsync(new Uri(serviceUrl)))
                return await r.Content.ReadAsStringAsync();
        }
        public static async Task<string> FindTwoPointsLength(List<PointGeo> points)
        {
            string serviceUrl = $"{url}findTwoPointsLength/";
            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(points), Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await client.PostAsync(serviceUrl, httpContent))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static void Deneme(List<PointGeo> points)
        {
            var result=GeoService.FindTwoPointsLength(points).Result;
            L length = JsonConvert.DeserializeObject<L>(result);
            Console.WriteLine(length.length);
        }
        
    }
}
