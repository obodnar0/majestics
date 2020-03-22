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
                             , IForumService forumService)
        {
            _contextAccessor = contextAccessor;
            _forumService = forumService;
        }

        /// <summary>
        /// Dy default returns 20 latest posts
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet("/api/Forum/[action]")]
        public ActionResult GetLatestPosts(int? count)
        {
            return _forumService.GetPosts(count);
        }

        [HttpPut("/api/Forum/[action]")]
        public async Task<ActionResult> AddPost([FromBody]AddPostRequest request)
        {
            if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return _forumService.AddPost(request, Guid.Parse(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
            }

            var result = Result.GetResult("Forbidden", HttpStatusCode.Forbidden);
            return result;
        }

        [HttpDelete("/api/Forum/[action]")]
        public async Task<ActionResult> DeletePost(int postId)
        {
            if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return _forumService.DeletePost(postId);
            }

            var result = Result.GetResult("Forbidden", HttpStatusCode.Forbidden);
            return result;
        }

        [HttpPost("/api/Forum/[action]")]
        public async Task<ActionResult> ChangePost([FromBody]EditPostRequest request)
        {
            if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return _forumService.ChangePost(request, Guid.Parse(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
            }

            var result = Result.GetResult("Forbidden", HttpStatusCode.Forbidden);
            return result;
        }
    }
}