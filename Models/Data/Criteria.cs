using System.Text.Json.Serialization;

namespace Majestics.Models.Data
{
    public class Criteria : BaseDbModel
    {
         public string Name { get; set; }

         public string Description { get; set; }

         public int ContestId { get; set; }

         [JsonIgnore]
         public virtual Contest.dto.Contest Contest { get; set; }
    }
}
