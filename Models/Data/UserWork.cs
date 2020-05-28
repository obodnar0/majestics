using System;
using System.ComponentModel.DataAnnotations;

namespace Majestics.Models.Data
{
    public class UserWork
    {
        [Key]
        public Guid UserId { get; set; }

        [Key]
        public string ImageName { get; set; }
    }
}
