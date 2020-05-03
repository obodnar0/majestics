using System;

namespace Majestics.Models.Post
{
    public class Post : BaseDbModel
    {
        public DateTime CreationTime { get; set; }

        public DateTime? LastChanged { get; set; }

        public string Data { get; set; }

        public string CreatedByUserId { get; set; }

        public string ChangedByUserId { get; set; }

        public virtual User CreatedByUser { get; set; }

        public virtual User ChangedByUser { get; set; }
    }
}
