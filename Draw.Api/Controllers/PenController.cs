using Draw.Api.Models;
using Draw.Business.Abstract;
using Draw.Business.DependencyResolvers.Ninject;
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

        [HttpGet("pens")]
        public async Task<IActionResult> GetPens()
        {
            return ActionResultInstance(await _penManager.GetAllAsync(GetUserId(User)));
        }

        [HttpGet("penswithatt")]
        public async Task<IActionResult> GetPensWithAtt()
        {
            return ActionResultInstance(await _penManager.GetAllWithAttAsync(GetUserId(User)));
        }

        [HttpGet("pens/{id}")]
        public async Task<IActionResult> GetPen(int id)
        {
            return ActionResultInstance(await _penManager.GetAsync(GetUserId(User), id));
        }

        //[HttpGet("pens/{id}/color")]
        //public async Task<IActionResult> GetPenAtColor(int id)
        //{
        //    return ActionResultInstance(await _penManager.GetColorAsync(GetUserId(User), id));
        //}

        [HttpGet("pens/{id}/penstyle")]
        public async Task<IActionResult> GetPenAtPenStyle(int id)
        {
            return ActionResultInstance(await _penManager.GetPenStyleAsync(GetUserId(User), id));
        }


        [HttpPost("pens/add")]
        public async Task<IActionResult> AddPens(PenRequest request)
        {
            return ActionResultInstance(await _penManager.AddAllAsync(request.pens));
        }

        [HttpDelete("pens/delete")]
        public async Task<IActionResult> DeletePens(List<int> ids)
        {
            return ActionResultInstance(await _penManager.DeleteAllAsync(GetUserId(User), ids));
        }

        [HttpPut("pens/update")]
        public async Task<IActionResult> UpdatePens(PenRequest request)
        {
            return ActionResultInstance(await _penManager.UpdateAllAsync(GetUserId(User), request.pens));
        }

    }
}
