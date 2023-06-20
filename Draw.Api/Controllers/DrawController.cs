using Draw.Api.Models;
using Draw.Business.Abstract;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Core.Aspects.PostSharp.LoggingAspects;
using Draw.Core.DTOs.Concrete;
using Draw.Core.Services;
using Draw.DrawLayer.Concrete.Model;
using Draw.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using System.IO;
using System.Net;
using System.Net.Http.Headers;

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

        //[LogAspect]
        [HttpPost("saveDraw")]
        public async Task<IActionResult> SaveDraw(DrawBoxDTO drawBox)
        {
            return await _drawService.SaveDraw(GetUserInfo(User).id, drawBox);
        }

        [HttpPost("readDraw")]
        public async Task<IActionResult> ReadDraw([FromForm]IFormFile drawFile)
        {
            return ActionResultInstance(await _drawService.ReadDraw(GetUserInfo(User).id, drawFile.OpenReadStream()));
        }



    }
}
