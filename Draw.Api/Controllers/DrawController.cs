using Draw.Api.Models;
using Draw.Business.Abstract;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.DrawLayer.Concrete.Elements;
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

    }





}
