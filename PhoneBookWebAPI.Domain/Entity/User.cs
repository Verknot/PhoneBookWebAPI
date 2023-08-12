using PhoneBookWebAPI.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PhoneBookWebAPI.Domain.Entity
{
    public class User : EntityBase
    {

        [JsonPropertyName("name")]
        public Name Name { get; set; }
        [JsonPropertyName("phone")]
        public string PhoneNumber { get; set; }
        [JsonPropertyName("dob")]
        public Birthday Birthday { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("picture")]
        public Picture Pictures { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
    }

}
