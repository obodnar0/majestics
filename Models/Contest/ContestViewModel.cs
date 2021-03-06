﻿using System.Collections.Generic;

namespace Majestics.Models.Contest
{
    public class ContestViewModel
    {
        public int ContestId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<WorkViewModel> Works { get; set; }
    }
}
