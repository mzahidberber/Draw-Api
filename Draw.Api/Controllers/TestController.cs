using Draw.Core.Services;
using Draw.Entities.Concrete.Draw;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;

namespace Draw.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : CustomBaseController
    {
        [HttpGet("saveDrawtest")]
        public HttpResponseMessage test()
        {

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write("test");
            writer.Flush();
            stream.Position = 0;

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(stream.ToArray())
            };
            result.Content.Headers.ContentDisposition =
                new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = "test.df"
                };
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/octet-stream");
            return result;
        }
        //[HttpGet("saveDrawtest2")]
        //public IActionResult test2()
        //{

        //    var stream = new MemoryStream();
        //    var writer = new StreamWriter(stream);
        //    writer.Write("test");
        //    writer.Flush();
        //    stream.Position = 0;

        //    var result = new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new ByteArrayContent(stream.GetBuffer())
        //    };
        //    result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
        //    {
        //        FileName = "test.pdf"
        //    };
        //    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

        //    var response = ResponseMessage(result);

        //    return response;
        //}
        [HttpGet("saveDrawtest1")]
        public IActionResult test1()
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write("test");
            writer.Write("test");
            writer.Write("test");
            writer.Write("test");
            writer.Flush();
            stream.Position = 0;
            return File(stream, "application/octet-stream", "draw.df");
        }

        [HttpPost("test")]
        public async Task<object> deneme(double p1x, double p1y, double p2x, double p2y, double p3x, double p3y)
        {
            //var result=await new GeoService().FindTwoPointsLength(
            //    new Point { PointX=p1x,PointY=p1y},
            //    new Point { PointX=p2x,PointY=p2y}
            //    );
            var result1 = await new GeoService().FindCenterAndRadius(
                new Point { X = p1x, Y = p1y },
                new Point { X = p2x, Y = p2y },
                new Point { X = p3x, Y = p3y }
                );
            return result1.centerPoint;
        }
    }
}
