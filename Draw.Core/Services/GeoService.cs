using Draw.Core.CrosCuttingConcers.Handling;
using Draw.Core.Mapper;
using Draw.Core.Services.Abstract;
using Draw.Core.Services.Model;
using Draw.Entities.Concrete;
using System.Text;
using System.Text.Json;

namespace Draw.Core.Services
{

    public class GeoService:IGeoService
    {
        public string url { get;private set; }
        static HttpClient client = new HttpClient();

        public GeoService()
        {
            var urlE= Environment.GetEnvironmentVariable("geoUrl");
            if (urlE != null)
                this.url = urlE;
            else throw new Exception();
        }

        private string GetUrl(string urlHead) => url+urlHead;
        private StringContent GetContent<T>(T data) => new StringContent(JsonSerializer.Serialize(data),Encoding.UTF8, "application/json");
        
        public async Task<GeoRequest<double>> FindTwoPointsLength(Point p1,Point p2)
        {
            var points= CoreObjectMapper.Mapper.Map<List<PointGeo>>(new List<Point>{p1,p2});

            using (HttpResponseMessage response = await client.PostAsync(
                GetUrl(GeoRequestUrls.findTwoPointsLength), 
                GetContent<List<PointGeo>>(points)))
            {
                //response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                GeoRequest<double>? data = JsonSerializer.Deserialize<GeoRequest<double>>(result);

                return data ?? throw new CustomException("GeoService Not Used");
            }
            
        }

        public async Task<GeoRequest<RadiusAndCenter>> FindCenterAndRadius(Point p1, Point p2, Point p3)
        {
            var points = CoreObjectMapper.Mapper.Map<List<PointGeo>>(new List<Point> { p1, p2,p3 });

            using (HttpResponseMessage response = await client.PostAsync(
                GetUrl(GeoRequestUrls.findCenterAndRadius),
                GetContent<List<PointGeo>>(points)))
            {
                //response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                GeoRequest<RadiusAndCenter>? data = JsonSerializer.Deserialize<GeoRequest<RadiusAndCenter>>(result);
                //Point dönmek gerekiyor pointGeo dönüyor
                return data ?? throw new CustomException("GeoService Not Used");
            }

        }

        public async Task<GeoRequest<double>> FindToSlopeLine(Point p1, Point p2)
        {
            var points = CoreObjectMapper.Mapper.Map<List<PointGeo>>(new List<Point> { p1, p2 });

            using (HttpResponseMessage response = await client.PostAsync(
                GetUrl(GeoRequestUrls.findToSlopeLine),
                GetContent<List<PointGeo>>(points)))
            {
                //response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                GeoRequest<double>? data = JsonSerializer.Deserialize<GeoRequest<double>>(result);

                return data ?? throw new CustomException("GeoService Not Used");
            }

        }







        //public static async Task<string> Get(string method)
        //{
        //    string serviceUrl = $"{url}{method}";
        //    using (var r = await client.GetAsync(new Uri(serviceUrl)))
        //        return await r.Content.ReadAsStringAsync();
        //}

        //public async Task<D> Request<D>(string url,)

    }
}
