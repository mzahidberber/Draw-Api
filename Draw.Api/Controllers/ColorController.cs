using Draw.Api.Models;
using Draw.Business.Abstract;
using Draw.Business.DependencyResolvers.Ninject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ColorController : CustomBaseController
    {
        private readonly IColorService _colorManager;

        public ColorController(IColorService colorService)
        {
            _colorManager = BusinessInstanceFactory.GetInstance<IColorService>();
        }
        [Authorize]
        [HttpGet("colors")]
        public async Task<IActionResult> GetColors()
        {
            return ActionResultInstance(await _colorManager.GetAllAsync(GetUserId(User)));
        }
        [Authorize]
        [HttpGet("colors/{id}")]
        public async Task<IActionResult> GetColor(int id)
        {
            return ActionResultInstance(await _colorManager.GetAsync(GetUserId(User),id));
        }
        
        [Authorize(Roles = "admin,manager")]
        [HttpPost("colors/add")]
        public async Task<IActionResult> AddColors(ColorRequest request)
        {
            return ActionResultInstance(await _colorManager.AddAllAsync(request.colors));
        }
        
        [Authorize(Roles = "admin,manager")]
        [HttpDelete("colors/delete")]
        public async Task<IActionResult> DeleteColors(List<int> request)
        {
            return ActionResultInstance(await _colorManager.DeleteAllAsync(GetUserId(User), request));
        }
        
        [Authorize(Roles = "admin,manager")]
        [HttpPut("colors/update")]
        public async Task<IActionResult> UpdateColors(ColorRequest request)
        {
            return ActionResultInstance(await _colorManager.UpdateAllAsync(GetUserId(User), request.colors));
        }

    }
}
