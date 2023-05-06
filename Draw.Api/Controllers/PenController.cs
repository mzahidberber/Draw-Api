using Draw.Api.Models;
using Draw.Business.Abstract;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Core.Aspects.PostSharp.LoggingAspects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PenController : CustomBaseController
    {
        private IPenService _penManager;

        public PenController()
        {
            _penManager = BusinessInstanceFactory.GetInstance<IPenService>();
        }
        [LogAspect]
        [HttpGet("pens")]
        public async Task<IActionResult> GetPens()
        {
            return ActionResultInstance(await _penManager.GetAllAsync(GetUserInfo(User).id));
        }
        [LogAspect]
        [HttpGet("penswithatt")]
        public async Task<IActionResult> GetPensWithAtt()
        {
            return ActionResultInstance(await _penManager.GetAllWithAttAsync(GetUserInfo(User).id));
        }
        [LogAspect]
        [HttpGet("pens/{id}")]
        public async Task<IActionResult> GetPen(int id)
        {
            return ActionResultInstance(await _penManager.GetAsync(GetUserInfo(User).id, id));
        }

        //[HttpGet("pens/{id}/color")]
        //public async Task<IActionResult> GetPenAtColor(int id)
        //{
        //    return ActionResultInstance(await _penManager.GetColorAsync(GetUserId(User), id));
        //}
        [LogAspect]
        [HttpGet("pens/{id}/penstyle")]
        public async Task<IActionResult> GetPenAtPenStyle(int id)
        {
            return ActionResultInstance(await _penManager.GetPenStyleAsync(GetUserInfo(User).id, id));
        }

        [LogAspect]
        [HttpPost("pens/add")]
        public async Task<IActionResult> AddPens(PenRequest request)
        {
            return ActionResultInstance(await _penManager.AddAllAsync(request.pens));
        }
        [LogAspect]
        [HttpDelete("pens/delete")]
        public async Task<IActionResult> DeletePens(List<int> ids)
        {
            return ActionResultInstance(await _penManager.DeleteAllAsync(GetUserInfo(User).id, ids));
        }
        [LogAspect]
        [HttpPut("pens/update")]
        public async Task<IActionResult> UpdatePens(PenRequest request)
        {
            return ActionResultInstance(await _penManager.UpdateAllAsync(GetUserInfo(User).id, request.pens));
        }

    }
}
