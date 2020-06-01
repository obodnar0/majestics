using Majestics.Models.Users;

namespace Majestics.Models.Contest
{
    public class WorkViewModel
    {
        public int WorkId { get; set; }

        public string Source { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal AnonMark { get; set; }

        public decimal UsersMark { get; set; }

        public decimal JuryMark { get; set; }

        public decimal AverageMark => AnonMark * 0.1M + UsersMark * 0.3M + JuryMark * 0.6M;

        public UserViewModel User { get; set; }
    }
}
