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
        public PictureType Type { get; set; }
        public Uri Url { get; set; }
        public byte[] Image { get; set; }
        public string Path { get; set; }
    }

}
