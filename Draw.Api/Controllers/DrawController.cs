using Draw.Api.Models;
using Draw.Business.Abstract;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Core.Services;
using Draw.DrawLayer.Concrete.Model;
using Draw.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DrawController : CustomBaseController
    {
        private readonly IDrawService _drawService;

        public DrawController()
        {
            _drawService = BusinessInstanceFactory.GetInstance<IDrawService>();
        }

        [HttpPost("startCommand")]
        public async Task<IActionResult> StartCommand(StartCommandRequest request)
        {
            return ActionResultInstance(await _drawService.StartCommand(GetUserId(User),request.command,request.DrawId,request.LayerId,request.PenId));
        }

        [HttpPost("addCoordinate")]
        public async Task<IActionResult> AddPoint(PointD point)
        {
            return ActionResultInstance(await _drawService.AddCoordinate(GetUserId(User),point));
        }
        
        [HttpPost("stopCommand")]
        public async Task<IActionResult> StopCommad()
        {
            return ActionResultInstance(await _drawService.StopCommand(GetUserId(User)));
        }

        [HttpPost("setRadius")]
        public async Task<IActionResult> SetRadius([FromBody]double radius)
        {
            return ActionResultInstance(await _drawService.SetRadius(GetUserId(User),radius));
        }


        [HttpPost("setElementsId")]
        public async Task<IActionResult> SetElementsId([FromBody] List<int> setElementsId)
        {
            return ActionResultInstance(await _drawService.SetElementsId(GetUserId(User), setElementsId));
        }

        [HttpPost("test")]
        public async Task<object> deneme(double p1x, double p1y, double p2x, double p2y, double p3x, double p3y)
        {
            //var result=await new GeoService().FindTwoPointsLength(
            //    new Point { PointX=p1x,PointY=p1y},
            //    new Point { PointX=p2x,PointY=p2y}
            //    );
            var result1 = await new GeoService().FindCenterAndRadius(
                new Point { PointX = p1x, PointY = p1y },
                new Point { PointX = p2x, PointY = p2y },
                new Point { PointX = p3x, PointY = p3y }
                );
            return result1.data.centerPoint;
        }

    }






}
