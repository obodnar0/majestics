using System;
using System.ComponentModel.DataAnnotations;

namespace Majestics.Models.Data
{
    public class UserContest : BaseDbModel
    {
        public int ContestId { get; set; }

        public string UserId { get; set; }

        public virtual Contest.dto.Contest Contest { get; set; }

        public virtual User User { get; set; }
    }
}
