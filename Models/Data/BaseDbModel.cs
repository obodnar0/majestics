using System.ComponentModel.DataAnnotations;
using Majestics.Helpers.Enums;

namespace Majestics.Models
{
    public class BaseDbModel
    {
        [Key]
        public int Id { get; set; }

        public ModelState State { get; set; }
    }
}
