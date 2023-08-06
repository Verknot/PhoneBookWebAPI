using PhoneBookWebAPI.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.Domain.Responce
{


    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }

        public StatusCode StatusCode { get; set; }

        public List<T> Data { get; set; }

    }

    public interface IBaseResponse<T>
    {
        public List<T> Data { get; set; }

        public string Description { get; set; }

        public StatusCode StatusCode { get; set; }
    }
}
