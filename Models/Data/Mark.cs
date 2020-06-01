using System;
using Majestics.Helpers.Enums;

namespace Majestics.Models.Data
{
    public class Mark : BaseDbModel
    {
        public byte Value { get; set; }

        public int CriteriaId { get; set; }

        public UserType? UserType { get; set; }

        public DateTime CreationDate { get; set; }

        public string IdCode { get; set; }

        public string UserId { get; set; }
        
        public virtual User User { get; set; }

        public int WorkId { get; set; }

        public virtual Work Work { get; set; }
    }
}
