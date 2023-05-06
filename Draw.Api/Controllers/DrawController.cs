﻿using Draw.Api.Models;
using Draw.Business.Abstract;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Core.Aspects.PostSharp.LoggingAspects;
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


        [LogAspect]
        [HttpPost("startCommand")]
        public async Task<IActionResult> StartCommand(StartCommandRequest request)
        {
            return ActionResultInstance(await _drawService.StartCommand(GetUserInfo(User).id,request.command,request.DrawId,request.LayerId,request.PenId));
        }

        [LogAspect]
        [HttpPost("addCoordinate")]
        public async Task<IActionResult> AddPoint(PointD point)
        {
            return ActionResultInstance(await _drawService.AddCoordinate(GetUserInfo(User).id, point));
        }

        [LogAspect]
        [HttpPut("stopCommand")]
        public async Task<IActionResult> StopCommad()
        {
            return ActionResultInstance(await _drawService.StopCommand(GetUserInfo(User).id));
        }

        [LogAspect]
        [HttpPut("setRadius")]
        public async Task<IActionResult> SetRadius([FromBody]double radius)
        {
            return ActionResultInstance(await _drawService.SetRadius(GetUserInfo(User).id,radius));
        }

        [LogAspect]
        [HttpPut("setElementsId")]
        public async Task<IActionResult> SetElementsId([FromBody] List<int> setElementsId)
        {
            return ActionResultInstance(await _drawService.SetElementsId(GetUserInfo(User).id, setElementsId));
        }

        [LogAspect]
        [HttpPut("setIsFinish")]
        public async Task<IActionResult> SetIsFinish(bool finish=true)
        {
            return ActionResultInstance(await _drawService.SetIsFinish(GetUserInfo(User).id, finish));
        }

        //[HttpPut("saveElements")]
        //public async Task<IActionResult> SaveElements(List<ElementDTO> elements)
        //{
        //    return ActionResultInstance(await _drawService.SaveElements(GetUserId(User), elements));
        //}

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
