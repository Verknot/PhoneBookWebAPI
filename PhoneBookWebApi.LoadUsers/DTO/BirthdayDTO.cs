using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.LoadUsers.DTO
{
    public class BirthdayDTO
    {
        public DateTime? date { get; set; }

        public int age { get; set; }
    }
}
