using PhoneBookWebAPI.Domain.Entity.Base;
using PhoneBookWebAPI.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.Domain.Entity
{
        public class Picture
        {
            [JsonPropertyName("large")]
            public string Large { get; set; }
            [JsonPropertyName("medium")]
            public string Medium { get; set; }
            [JsonPropertyName("thumbnail")]
            public string Thumbnail { get; set; }
            [JsonIgnore]  
            public int? UserId { get; set; }
            [JsonIgnore]
            public User User { get; set; }

        }

}
