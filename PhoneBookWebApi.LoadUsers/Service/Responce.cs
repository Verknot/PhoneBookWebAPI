using PhoneBookWebAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.LoadUsers.Service
{
    public class Responce
    {
        [JsonPropertyName("results")]
        public List<User> resultst { get; set; }

        public bool success { get; set; }


    }
}
