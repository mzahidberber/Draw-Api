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
    public class ElementController : CustomBaseController
    {
        private readonly IElementService _elementManager;

        public ElementController()
        {
            _elementManager= BusinessInstanceFactory.GetInstance<IElementService>();
        }

        [HttpGet("elements")]
        public async Task<IActionResult> GetElements()
        {
            return ActionResultInstance(await _elementManager.GetAllAsync(GetUserId(User)));
        }

        [HttpGet("elementsbydraw")]
        public async Task<IActionResult> GetElementsByDraw(int drawId)
        {
            return ActionResultInstance(await _elementManager.GetAllByDrawAsync(GetUserId(User),drawId));
        }

        [HttpGet("elementsbylayer")]
        public async Task<IActionResult> GetElementsByLayer(int layerId)
        {
            return ActionResultInstance(await _elementManager.GetAllByLayerAsync(GetUserId(User),layerId));
        }

        [HttpPost("elements/add")]
        public async Task<IActionResult> AddElements(ElementRequest request)
        {
            return ActionResultInstance(await _elementManager.GetAllAsync(GetUserId(User)));
        }

        [HttpDelete("elements/delete")]
        public async Task<IActionResult> DeleteElements(List<int> ids)
        {
            return ActionResultInstance(await _elementManager.DeleteAllAsync(GetUserId(User), ids));
        }

        [HttpPut("elements/update")]
        public async Task<IActionResult> UpdateElements(ElementRequest request)
        {
            return ActionResultInstance(await _elementManager.UpdateAllAsync(GetUserId(User), request.elements));
        }

        [HttpGet("elements/{id}")]
        public async Task<IActionResult> GetElement(int id)
        {
            return ActionResultInstance(await _elementManager.GetAsync(GetUserId(User), id));
        }

        [HttpGet("elements/{id}/elementType")]
        public async Task<IActionResult> GetElementType(int id)
        {
            return ActionResultInstance(await _elementManager.GetElementTypeAsync(GetUserId(User), id));
        }

        [HttpGet("elements/{id}/pen")]
        public async Task<IActionResult> GetPen(int id)
        {
            return ActionResultInstance(await _elementManager.GetPenAsync(GetUserId(User), id));
        }

        [HttpGet("elements/{id}/layer")]
        public async Task<IActionResult> GetLayer(int id)
        {
            return ActionResultInstance(await _elementManager.GetLayerAsync(GetUserId(User), id));
        }
        [HttpGet("elements/{id}/radiuses")]
        public async Task<IActionResult> GetRadiuses(int id)
        {
            return ActionResultInstance(await _elementManager.GetRadiusesAsync(GetUserId(User), id));
        }

        [HttpGet("elements/{id}/ssangles")]
        public async Task<IActionResult> GetSSAngles(int id)
        {
            return ActionResultInstance(await _elementManager.GetSSAnglesAsync(GetUserId(User), id));
        }

        [HttpGet("elements/{id}/points")]
        public async Task<IActionResult> GetPoints(int id)
        {
            return ActionResultInstance(await _elementManager.GetPointsAsync(GetUserId(User), id));
        }


    }
}
