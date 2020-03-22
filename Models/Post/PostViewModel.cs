using System;

namespace Majestics.Models.Post
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string Data { get; set; }

        public string CreatorName { get; set; }

        public string LastChangedName { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
