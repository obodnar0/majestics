using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Majestics.Models.Common;
using Majestics.Models.Contest;
using Majestics.Models.Users;
using Majestics.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ActionResult = Majestics.Models.Common.ActionResult;

namespace Majestics.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;

        public UsersController(IUserService userService
                               , IHttpContextAccessor contextAccessor)
        {
            _userService = userService;
            _contextAccessor = contextAccessor;
        }

        [HttpPost("Update")]
        public async Task<Models.Common.ActionResult> UpdateUserInfo([FromBody]UserInfoViewModel info)
        {
            try
            {
                var result = await _userService.UpdateInfo(info, _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Error(ex);
            }
        }

        [HttpGet("Get")]
        public async Task<ActionResult> GetTopRatedWorks()
        {
            try
            {
                var result = await _userService.GetInfo(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Error(ex);
            }
        }
    }
}
