using Majestics.Models.Users;

namespace Majestics.Models.Contest
{
    public class WorkViewModel
    {
        public string Source { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public byte AnonMark { get; set; }

        public byte UsersMark { get; set; }

        public byte JuryMark { get; set; }

        public byte AverageMark { get; set; }

        public UserViewModel User { get; set; }
    }
}
