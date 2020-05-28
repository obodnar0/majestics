using Newtonsoft.Json;

namespace Majestics.Models.Contest
{
    public class MarkWorkRequest
    {
        [JsonIgnore]
        public string UserId { get; set; }

        [JsonIgnore]
        public string Ip { get; set; }

        public int CriteriaId { get; set; }

        public int WorkId { get; set; }

        public byte Mark { get; set; }
    }
}
