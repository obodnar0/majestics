using System;

namespace Majestics.Models.Post
{
    public class Post : BaseDbModel
    {
        public DateTime CreationTime { get; set; }

        public DateTime? LastChanged { get; set; }

        public string Data { get; set; }

        public Guid CreatedByUserId { get; set; }

        public Guid? ChangedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }

        public virtual ApplicationUser ChangedByUser { get; set; }
    }
}
