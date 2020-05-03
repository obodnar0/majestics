using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Majestics.Helpers.Enums;
using Majestics.Models.Data;

namespace Majestics.Models
{
    public class User : IdentityUser
    {
        public virtual IEnumerable<Post.Post> CreatedPosts { get; set; }

        public virtual IEnumerable<Post.Post> ChangedPosts { get; set; }

        public virtual IEnumerable<UserContest> Contests { get; set; }

        public virtual IEnumerable<Work> Works { get; set; }

        public virtual IEnumerable<Mark> Marks { get; set; }

        public UserType? UserType { get; set; }

        public string Institute { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
