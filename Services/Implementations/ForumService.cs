using Majestics.Data;
using Majestics.Helpers.Enums;
using Majestics.Models.Common;
using Majestics.Models.Post;
using Majestics.Services.Abstractions;
using System;
using System.Linq;
using System.Net;

namespace Majestics.Services.Implementations
{
    public class ForumService : IForumService
    {
        private readonly ApplicationDbContext _dbContext;

        public ForumService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult AddPost(AddPostRequest post, Guid userId)
        {
            try
            {
                _dbContext.Posts.Add(new Post
                {
                    Data = post.Data,
                    CreatedByUserId = userId.ToString(),
                    CreationTime = DateTime.Now
                });
                _dbContext.SaveChanges();

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }

        public ActionResult GetPosts(int? count = null, Func<Post, bool> where = null)
        {
            try
            {
                var result = _dbContext.Posts
                    .Where(x => x.State == ModelState.Active)
                    .OrderByDescending(x => x.CreationTime)
                    .Take(count ?? 20)
                    .AsEnumerable()
                    .Where(where ?? (x => true))
                    .Select(x => new PostViewModel
                    {
                        Id = x.Id,
                        Data = x.Data,
                        CreationTime = x.CreationTime,
                        CreatorName = x.CreatedByUser.UserName,
                        LastChangedName = x.ChangedByUser?.UserName
                    });

                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }

        public ActionResult DeletePost(int postId)
        {
            try
            {
                var result = _dbContext.Posts.FirstOrDefault(x => x.Id == postId);

                if (result == null)
                    return Result.GetResult("Post not found", HttpStatusCode.NotFound);

                result.State = ModelState.Deleted;

                _dbContext.SaveChanges();

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }

        public ActionResult ChangePost(EditPostRequest post, Guid userId)
        {
            try
            {
                var result = _dbContext.Posts.FirstOrDefault(x => x.Id == post.PostId);

                if (result == null)
                    return Result.GetResult("Post not found", HttpStatusCode.NotFound);

                result.Data = post.Data;
                result.LastChanged = DateTime.Now;
                result.ChangedByUserId = userId.ToString();

                _dbContext.SaveChanges();

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
