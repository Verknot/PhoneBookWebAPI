using PhoneBookWebAPI.Domain.Entity.Base;
using PhoneBookWebAPI.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.Domain.Entity
{
        public class Picture : EntityBase
        {
            public string large { get; set; }
            public string medium { get; set; }
            public string thumbnail { get; set; }

            public int? UserId { get; set; }

            public User User { get; set; }

        }

}
