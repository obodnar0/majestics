﻿using Majestics.Helpers.Enums;
using System.Collections.Generic;

namespace Majestics.Models.Data
{
    public class Work : BaseDbModel
    {
        public string Source { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int ContestId { get; set; }

        public virtual Contest.dto.Contest Contest { get; set; }

        public WorkState WorkStatus { get; set; }

        public IEnumerable<Mark> Marks { get; set; }
    }
}
