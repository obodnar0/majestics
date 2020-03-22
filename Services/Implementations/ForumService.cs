using Majestics.Models.Post;
using Majestics.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Majestics.Data;
using Majestics.Models.Common;

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
                    CreatedByUserId = userId,
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
                    .OrderByDescending(x => x.CreationTime)
                    .Take(count ?? 20)
                    .AsEnumerable()
                    .Where(where ?? (x => true));

                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
