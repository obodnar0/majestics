using Majestics.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ActionResult = Majestics.Models.Common.ActionResult;

namespace Majestics.Controllers
{
    [Authorize]
    public class DataController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly string _filesPath;
        private readonly string _filesHostingUrl;

        public DataController(IHttpContextAccessor contextAccessor
                            , IConfiguration config)
        {
            _contextAccessor = contextAccessor;
            _filesPath = config.GetSection("FilesFolderRootPath").Value;
            _filesHostingUrl = config.GetSection("FilesUrl").Value;
        }

        [HttpPost("/Data/UploadFile")]
        public async Task<ActionResult> Upload(IFormFile file)
        {
            var filename =  _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                       + "dt"
                       + DateTime.Now.Ticks
                       + "." + file.ContentType.Split('/').Last();

            await using (var localFile = System.IO.File.OpenWrite(_filesPath + filename))
            {
                await using var uploadedFile = file.OpenReadStream();
                await uploadedFile.CopyToAsync(localFile);
            }

            return Result.Ok(_filesHostingUrl + filename);
        }
    }
}
