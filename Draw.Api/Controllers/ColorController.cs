using Draw.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ColorController : CustomBaseController
    {

        [HttpGet("colors")]
        public async Task<IActionResult> GetColors()
        {
            return ActionResultInstance(await _colorManager.GetAllAsync());
        }

        [HttpGet("colors/{id}")]
        public async Task<IActionResult> GetColor(int id)
        {
            return ActionResultInstance(await _colorManager.GetAsync(id));
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
            return ActionResultInstance(await _colorManager.DeleteAllAsync(request));
        }
        
        [Authorize(Roles = "admin,manager")]
        [HttpPut("colors/update")]
        public async Task<IActionResult> UpdateColors(ColorRequest request)
        {
            return ActionResultInstance(await _colorManager.UpdateAllAsync(request.colors));
        }

    }
}
