
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.Domain.Entity
{
    public class Birthday
    {
        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }
        [JsonPropertyName("age")]
        public int age { get; set; }
    }
}
