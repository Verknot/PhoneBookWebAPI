using PhoneBookWebAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.DAL.Repository
{
    public class UserRepository
    {
        public async Task<int> SaveUsersAsync(IEnumerable<User> users)
        {
            int result = 0;
            using (var context = new AppDataContext())
            {
                context.Users.AddRange(users);
                result = await context.SaveChangesAsync();
            }

            return result;
        }
    }
}
