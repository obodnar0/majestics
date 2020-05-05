using Majestics.Models.Common;
using Majestics.Models.Post;
using System;

namespace Majestics.Services.Abstractions
{
    public interface IForumService
    {
        ActionResult GetPosts(int? count = null, Func<Post, bool> where = null);

        ActionResult AddPost(AddPostRequest post, Guid userId);

        ActionResult DeletePost(int postId);

        ActionResult ChangePost(EditPostRequest post, Guid userId);
    }
}
