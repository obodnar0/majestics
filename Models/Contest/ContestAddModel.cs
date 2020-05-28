using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Majestics.Models.Contest
{
    public class ContestAddModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsOpen { get; set; }
    }
}
