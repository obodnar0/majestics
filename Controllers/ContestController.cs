using Majestics.Models.Contest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using Majestics.Models.Common;
using Majestics.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using ActionResult = Majestics.Models.Common.ActionResult;

namespace Majestics.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ContestController : ControllerBase
    {
        private readonly IContestService _contestService;
        private readonly IHttpContextAccessor _contextAccessor;

        public ContestController(IContestService contestService
                               , IHttpContextAccessor contextAccessor)
        {
            _contestService = contestService;
            _contextAccessor = contextAccessor;
        }

        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<ActionResult> GetContests()
        {
            try
            {
                var result = await _contestService.GetAllContestsAsync();

                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Error(ex);
            }
        }

        [HttpGet("Get")]
        [AllowAnonymous]
        public async Task<ActionResult> GetContests([FromQuery]int contestId)
        {
            try
            {
                var result = await _contestService.GetContestAsync(contestId);

                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Error(ex);
            }
        }

        [HttpGet("GetCriterias")]
        [AllowAnonymous]
        public async Task<ActionResult> GetCriterias()
        {
            try
            {
                var result = await _contestService.GetCriteriasAsync();

                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Error(ex);
            }
        }

        [HttpGet("GetWorkDetails")]
        [AllowAnonymous]
        public async Task<ActionResult> GetWork([FromQuery]string workId)
        {
            try
            {
                var result = await _contestService.GetWorkAsync(int.Parse(workId));

                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Error(ex);
            }
        }

        [HttpPost("AddWork")]
        public async Task<ActionResult> AddWork(AddWorkRequest work) 
        {
            try
            {
                work.UserId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                var result = await _contestService.AddWorkAsync(work);

                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Error(ex);
            }
        } 
        
        [HttpPost("CreateContest")]
        public async Task<ActionResult> CreateContestAsync(ContestAddModel request)
        {
            try
            {
                var result = await _contestService.CreateContestAsync(request);

                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Error(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost("AddMark")]
        public async Task<ActionResult> MarkWorkAsync(MarkWorkRequest request)
        {
            try
            {
                if (_contextAccessor.HttpContext.User.IsAuthenticated())
                {
                    request.UserId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                }
                else
                {
                    request.UserId = null;
                }

                request.IdCode = _contextAccessor.HttpContext.Request.Cookies[".AspNetCore.Identity.Application"];

                var result = await _contestService.MarkWorkAsync(request);

                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Error(ex);
            }
        }
    }
}
