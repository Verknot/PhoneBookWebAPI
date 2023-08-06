using PhoneBookWebAPI.LoadUsers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.LoadUsers
{
    public class Responce
    {
        public List<UserDTO> results { get; set; }

        public bool success { get; set; }


    }
}
