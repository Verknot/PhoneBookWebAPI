using PhoneBookWebAPI.Domain.Entity.Base;
using PhoneBookWebAPI.Domain.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.Domain.Entity
{
    public class Person: EntityBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
