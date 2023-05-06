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
    public class ElementController : CustomBaseController
    {
        private readonly IElementService _elementManager;

        public ElementController()
        {
            _elementManager = BusinessInstanceFactory.GetInstance<IElementService>();
        }
        [LogAspect]
        [HttpGet("elements")]
        public async Task<IActionResult> GetElements()
        {
            return ActionResultInstance(await _elementManager.GetAllAsync(GetUserInfo(User).id));
        }
        [LogAspect]
        [HttpGet("elementswithatt")]
        public async Task<IActionResult> GetElementsWithAtt()
        {
            return ActionResultInstance(await _elementManager.GetAllWithAttAsync(GetUserInfo(User).id));
        }
        [LogAspect]
        [HttpGet("elementsbydraw")]
        public async Task<IActionResult> GetElementsByDraw(int drawId)
        {
            return ActionResultInstance(await _elementManager.GetAllByDrawAsync(GetUserInfo(User).id, drawId));
        }
        [LogAspect]
        [HttpGet("elementsbydrawwithatt")]
        public async Task<IActionResult> GetAllByDrawWithAttAsync(int drawId)
        {
            return ActionResultInstance(await _elementManager.GetAllByDrawWithAttAsync(GetUserInfo(User).id, drawId));
        }
        [LogAspect]
        [HttpGet("elementsbylayer")]
        public async Task<IActionResult> GetElementsByLayer(int layerId)
        {
            return ActionResultInstance(await _elementManager.GetAllByLayerAsync(GetUserInfo(User).id, layerId));
        }
        [LogAspect]
        [HttpGet("elementsbylayerwithatt")]
        public async Task<IActionResult> GetAllByLayerWithAttAsync(int layerId)
        {
            return ActionResultInstance(await _elementManager.GetAllByLayerWithAttAsync(GetUserInfo(User).id, layerId));
        }
        [LogAspect]
        [HttpPost("elements/add")]
        public async Task<IActionResult> AddElements(ElementRequest request)
        {
            return ActionResultInstance(await _elementManager.AddAllAsync(request.elements));
        }
        [LogAspect]
        [HttpDelete("elements/delete")]
        public async Task<IActionResult> DeleteElements(List<int> ids)
        {
            return ActionResultInstance(await _elementManager.DeleteAllAsync(GetUserInfo(User).id, ids));
        }
        [LogAspect]
        [HttpPut("elements/update")]
        public async Task<IActionResult> UpdateElements(ElementRequest request)
        {
            return ActionResultInstance(await _elementManager.UpdateAllAsync(GetUserInfo(User).id, request.elements));
        }
        [LogAspect]
        [HttpGet("elements/{id}")]
        public async Task<IActionResult> GetElement(int id)
        {
            return ActionResultInstance(await _elementManager.GetAsync(GetUserInfo(User).id, id));
        }
        [LogAspect]
        [HttpGet("elements/{id}/elementType")]
        public async Task<IActionResult> GetElementType(int id)
        {
            return ActionResultInstance(await _elementManager.GetElementTypeAsync(GetUserInfo(User).id, id));
        }
        [LogAspect]
        [HttpGet("elements/{id}/pen")]
        public async Task<IActionResult> GetPen(int id)
        {
            return ActionResultInstance(await _elementManager.GetPenAsync(GetUserInfo(User).id, id));
        }
        [LogAspect]
        [HttpGet("elements/{id}/layer")]
        public async Task<IActionResult> GetLayer(int id)
        {
            return ActionResultInstance(await _elementManager.GetLayerAsync(GetUserInfo(User).id, id));
        }
        [LogAspect]
        [HttpGet("elements/{id}/radiuses")]
        public async Task<IActionResult> GetRadiuses(int id)
        {
            return ActionResultInstance(await _elementManager.GetRadiusesAsync(GetUserInfo(User).id, id));
        }
        [LogAspect]
        [HttpGet("elements/{id}/ssangles")]
        public async Task<IActionResult> GetSSAngles(int id)
        {
            return ActionResultInstance(await _elementManager.GetSSAnglesAsync(GetUserInfo(User).id, id));
        }
        [LogAspect]
        [HttpGet("elements/{id}/points")]
        public async Task<IActionResult> GetPoints(int id)
        {
            return ActionResultInstance(await _elementManager.GetPointsAsync(GetUserInfo(User).id, id));
        }


    }
}
