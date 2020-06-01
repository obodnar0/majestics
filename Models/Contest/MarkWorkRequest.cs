using Newtonsoft.Json;

namespace Majestics.Models.Contest
{
    public class MarkWorkRequest
    {
        [JsonIgnore]
        public string UserId { get; set; }

        [JsonIgnore]
        public string IdCode { get; set; }

        public string CriteriaId { get; set; }

        public string WorkId { get; set; }

        public string Mark { get; set; }
    }
}
