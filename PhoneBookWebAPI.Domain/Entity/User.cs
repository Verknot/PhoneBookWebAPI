using PhoneBookWebAPI.Domain.Entity.Base;
using PhoneBookWebAPI.Domain.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PhoneBookWebAPI.Domain.Entity
{
    public class User : EntityBase
    {
        public Name Name { get; set; }
        public string PhoneNumber { get; set; }
        public Birthday Birthday { get; set; }

        public string email { get; set; }

        public ICollection<UserPicture> Pictures { get; set; }

        public string Gender { get; set; }
    }

}
