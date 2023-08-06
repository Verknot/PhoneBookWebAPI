using PhoneBookWebAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.Domain.Links
{
    public class UserPicture
    {
        public int UserId { get; set; }
        public int PictureId { get; set; }

        public User User { get; set; }
        public Picture Picture { get; set; }
    }
}
