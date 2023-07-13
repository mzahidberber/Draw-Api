using Draw.Api.Models;
using Draw.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Draw.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ExeController: CustomBaseController
    {
        [HttpPost("checkVersion")]
        public Task<IActionResult> CheckVersion([FromBody] string version)
        {
            var vrsn = Environment.GetEnvironmentVariable("exeVersion");
            if (vrsn != null)
            {
                //var versionPath = Path.Combine(vrsn);
                //var v = System.IO.File.ReadAllText(versionPath);
                return Task.FromResult(
                    ActionResultInstance(
                        Response<CheckExe>.Success(vrsn == version ? new CheckExe { check=true,version= vrsn } : new CheckExe { check = false, version = vrsn }, 200)));
            }
            else
                return Task.FromResult(ActionResultInstance(Response<NoDataDto>.Fail("Unable to check version",503,true)));


        }

        //[HttpGet("downloadExe")]
        //public async Task<IActionResult> DownloadExe()
        //{
        //    var path = Environment.GetEnvironmentVariable("exePath");
        //    if (path != null)
        //    {
        //        var exePath = Path.Combine(path);
        //        var provider = new FileExtensionContentTypeProvider();
        //        if (!provider.TryGetContentType(exePath, out var contentType))
        //        {
        //            contentType = "application/octet-stream";
        //        }

        //        var bytes = await System.IO.File.ReadAllBytesAsync(exePath);
        //        return File(bytes, contentType, Path.GetFileName(exePath));
        //    }
        //    else
        //        return ActionResultInstance(Response<NoDataDto>.Fail("Unable to check version", 503, true));


        //}
    }
}
