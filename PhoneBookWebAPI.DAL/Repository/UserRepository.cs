using Microsoft.Extensions.Logging;
using PhoneBookWebAPI.DAL.Interfaces;
using PhoneBookWebAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.DAL.Repository
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly AppDataContext _db;

        public UserRepository(AppDataContext db)
        {
            _db = db;
        }

        public Task Create(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(User enity)
        {
            _db.Remove(enity);
         await   _db.SaveChangesAsync();

        }

        public IQueryable<User> GetAll()
        {
            return _db.Users;
        }


        public async Task<User> Update(User entity)
        {
           _db.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
