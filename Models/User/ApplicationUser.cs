using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Majestics.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual IEnumerable<Post.Post> CreatedPosts { get; set; }

        public virtual IEnumerable<Post.Post> ChangedPosts { get; set; }
    }
}
