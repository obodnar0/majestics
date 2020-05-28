using Newtonsoft.Json;

namespace Majestics.Models.Contest
{
    public class AddWorkRequest
    {
        public int ContestId { get; set; }

        public string Source { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public string UserId { get; set; }
    }
}
