﻿using Draw.Api.Models;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Core.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PenStylesController : CustomBaseController
    {

        private IPenStyleService _penStyleManager;

        public PenStylesController()
        {
            _penStyleManager = BusinessInstanceFactory.GetInstance<IPenStyleService>();
        }
        [Authorize]
        [HttpGet("penstyles")]
        public async Task<IActionResult> GetPenStyles()
        {
            return ActionResultInstance(await _penStyleManager.GetAllAsync());
        }
        [Authorize]
        [HttpGet("penstyles/{id}")]
        public async Task<IActionResult> GetPenStyle(int id)
        {
            return ActionResultInstance(await _penStyleManager.GetAsync(id));
        }
        
        [Authorize(Roles = "admin,manager")]
        [HttpPost("penstyles/add")]
        public async Task<IActionResult> AddPenStyles(PenStyleRequest request)
        {
            return ActionResultInstance(await _penStyleManager.AddAllAsync(request.penstyles));
        }
        
        [Authorize(Roles = "admin,manager")]
        [HttpDelete("penstyles/delete")]
        public async Task<IActionResult> DeletePenStyles(List<int> ids)
        {
            return ActionResultInstance(await _penStyleManager.DeleteAllAsync(ids));
        }
        
        [Authorize(Roles = "admin,manager")]
        [HttpPut("penstyles/update")]
        public async Task<IActionResult> UpdatePenStyles(PenStyleRequest request)
        {
            return ActionResultInstance(await _penStyleManager.UpdateAllAsync(request.penstyles));
        }
    }
}
