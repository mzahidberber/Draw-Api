using Draw.Api.Models;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Core.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ElementTypeController : CustomBaseController
    {
        private IElementTypeService _elementTypeManager;

        public ElementTypeController()
        {
            _elementTypeManager = BusinessInstanceFactory.GetInstance<IElementTypeService>();
        }
        [Authorize]
        [HttpGet("elementTypes")]
        public async Task<IActionResult> GetElementTypes()
        {
            return ActionResultInstance(await _elementTypeManager.GetAllAsync());
        }
        [Authorize]
        [HttpGet("elementTypes/{id}")]
        public async Task<IActionResult> GetElementType(int id)
        {
            return ActionResultInstance(await _elementTypeManager.GetAsync(id));
        }
        
        [Authorize(Roles = "admin,manager")]
        [HttpPost("elementTypes/add")]
        public async Task<IActionResult> AddElementTypes(ElementTypeRequest request)
        {
            return ActionResultInstance(await _elementTypeManager.AddAllAsync(request.elementTypes));
        }
        
        [Authorize(Roles = "admin,manager")]
        [HttpDelete("elementTypes/delete")]
        public async Task<IActionResult> DeletePenStyles(List<int> ids)
        {
            return ActionResultInstance(await _elementTypeManager.DeleteAllAsync( ids));
        }
        
        [Authorize(Roles = "admin,manager")]
        [HttpPut("elementTypes/update")]
        public async Task<IActionResult> UpdatePenStyles(ElementTypeRequest request)
        {
            return ActionResultInstance(await _elementTypeManager.UpdateAllAsync( request.elementTypes));
        }
    }
}
