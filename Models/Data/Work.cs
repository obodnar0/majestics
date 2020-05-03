using Majestics.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Majestics.Models.Data
{
    public class Work : BaseDbModel
    {
        public string Source { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public byte AnonMark => (byte)Marks.Where(x => x.User.UserType == null).Average(x => x.Value);

        public byte UsersMark => (byte)Marks.Where(x => x.User.UserType == UserType.User).Average(x => x.Value);

        public byte JuryMark => (byte)Marks.Where(x => x.User.UserType == UserType.Jury).Average(x => x.Value);

        public byte AverageMark => (byte)(AnonMark * 0.1 + UsersMark * 0.3 + JuryMark * 0.6);

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public WorkState WorkStatus { get; set; }

        public IEnumerable<Mark> Marks { get; set; }
    }
}
