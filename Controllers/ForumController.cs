using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using Majestics.Data;
using Majestics.Models;
using Majestics.Models.Common;
using Majestics.Models.Post;
using Majestics.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ActionResult = Majestics.Models.Common.ActionResult;

namespace Majestics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IForumService _forumService;

        public ForumController(IHttpContextAccessor contextAccessor
                             , IForumService forumService
                             , UserManager<ApplicationUser> userManager)
        {
            _contextAccessor = contextAccessor;
            _forumService = forumService;
        }

        /// <summary>
        /// Dy default returns 20 latest posts
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet("/GetLatestPosts")]
        public ActionResult GetLatestPosts(int? count)
        {
            return _forumService.GetPosts(count);
        }

        [HttpPost("/AddPost")]
        public async Task<ActionResult> AddPost(AddPostRequest request)
        {
            if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return _forumService.AddPost(request, Guid.Parse(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
            }

            var result = Result.GetResult("Forbidden", HttpStatusCode.Forbidden);
            return result;
        }
    }
}