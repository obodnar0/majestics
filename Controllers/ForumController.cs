using Majestics.Models.Post;
using Majestics.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using ActionResult = Majestics.Models.Common.ActionResult;

namespace Majestics.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
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
        [AllowAnonymous]
        [HttpGet("/api/Forum/[action]")]
        public ActionResult GetLatestPosts(int? count)
        {
            return _forumService.GetPosts(count);
        }

        [HttpPut("/api/Forum/[action]")]
        public ActionResult AddPost([FromBody]AddPostRequest request)
        {
            return _forumService.AddPost(request, Guid.Parse(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
        }

        [HttpDelete("/api/Forum/[action]")]
        public ActionResult DeletePost(int postId)
        {
            return _forumService.DeletePost(postId);
        }

        [HttpPost("/api/Forum/[action]")]
        public ActionResult ChangePost([FromBody]EditPostRequest request)
        {
            return _forumService.ChangePost(request, Guid.Parse(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
        }
    }
}