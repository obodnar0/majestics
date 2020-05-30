using Majestics.Models.Contest;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Majestics.Models.Users
{
    public class UserViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [JsonIgnore] public string FullName => FirstName + " " + LastName;

        public string Institute { get; set; }

        [JsonIgnore]
        public List<WorkViewModel> Works { get; set; }
    }
}
