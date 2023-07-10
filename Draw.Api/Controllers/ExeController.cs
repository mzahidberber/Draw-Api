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
            var path = Environment.GetEnvironmentVariable("exeVersionPath");
            if (path != null)
            {
                var versionPath = Path.Combine(path);
                var v = System.IO.File.ReadAllText(versionPath);
                return Task.FromResult(
                    ActionResultInstance(
                        Response<CheckExe>.Success(v == version ? new CheckExe { check=true,version=v} : new CheckExe { check = false, version = v }, 200)));
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
