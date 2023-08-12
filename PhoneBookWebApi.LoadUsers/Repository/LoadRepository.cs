using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PhoneBookWebAPI.DAL;
using PhoneBookWebAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.LoadUsers.Repository
{
    public class LoadRepository
    {
        private readonly AppDataContext _db;

        public LoadRepository(AppDataContext db)
        {
            _db = db;
        }
        public async Task<int> SaveUsersAsync(IEnumerable<User> users)
        {

            int result = 0;

                try
                {
                    _db.Users.AddRange(users);
                    result = await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            return result;
        }
    }
}
