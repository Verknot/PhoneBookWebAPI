using PhoneBookWebAPI.Domain.Entity;
using PhoneBookWebAPI.Domain.Responce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.Service.Interfaces
{
    public interface IUserService
    {
        Task<IBaseResponse<User>> Create(User user);

        Task<User> GetUser(long id);

        Task<List<User>> GetUsers();

        Task<List<User>> GetUser(int limit, bool sorByFIO, bool sortByBirthDay);
    }
}
