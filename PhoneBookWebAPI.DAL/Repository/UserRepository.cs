using Microsoft.Extensions.Logging;
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
                try
                {
                    context.Users.AddRange(users);
                    result = await context.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }
    }
}
