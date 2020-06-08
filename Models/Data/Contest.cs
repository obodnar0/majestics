using Majestics.Models.Data;
using System.Collections.Generic;

namespace Majestics.Models.Contest.dto
{
    public class Contest : BaseDbModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsOpen { get; set; }

        public IEnumerable<UserContest> Users { get; set; }

        public ICollection<Work> Works { get; set; }

        public ICollection<Criteria> Criterias { get; set; }
    }
}
