using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.LoadUsers.DTO
{
    public class UserDTO
    {
        public NameDTO name { get; set; }

        public BirthdayDTO dob { get; set; }
        public string phone { get; set; }
        public ICollection<PictureDTO> pictures { get; set; }

        public string gender { get; set; }

        public string email { get; set; }
    }
}
