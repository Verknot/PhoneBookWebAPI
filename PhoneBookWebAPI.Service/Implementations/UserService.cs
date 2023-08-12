using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhoneBookWebAPI.DAL;
using PhoneBookWebAPI.DAL.Interfaces;
using PhoneBookWebAPI.DAL.Repository;
using PhoneBookWebAPI.Domain.Entity;
using PhoneBookWebAPI.Domain.Enum;
using PhoneBookWebAPI.Domain.Responce;
using PhoneBookWebAPI.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IBaseRepository<User> _userRepository;

        public UserService(IBaseRepository<User> userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }


        public Task<IBaseResponse<User>> Create(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(long id)
        {
           // var test = _db.Users.FirstOrDefault(x => x.Id == id);
          // var test1 = _userRepository.GetAll().FirstOrDefault(x => x.Id == id);

            User user = new();
            try
            {
             user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if(user == null)
                {
                    _logger.LogInformation("Пользователь не найден");
                }

                _logger.LogInformation("Выборка прошла успешно");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return user;
        }

        public async Task<List<User>> GetUser(int limit, bool sorByFIO, bool sortByBirthDay)
        {
            List<User> users = new();
            try
            {
                if (users == null)
                {
                    
                    _logger.LogInformation("Пользователей нет");

                }
                users = await _userRepository.GetAll().Take(limit).ToListAsync();

                if (sorByFIO == true & sortByBirthDay == true)
                {
                 users = users.OrderBy(f => f.Name.Last).OrderBy(f => f.Birthday.Date).ToList();
                }

                else if (sorByFIO == true)
                {
                    users = users.OrderBy(f => f.Name.Last).ToList();
                }

                else if (sortByBirthDay == true)
                {
                    users = users.OrderBy(f => f.Birthday.Date).ToList();
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return users;
        }

        public async Task<List<User>> GetUsers()
        {


            List<User> users = new();
            try
            {
                if (users == null)
                {
                    _logger.LogInformation("Пользователей нет");
                }
                users = await _userRepository.GetAll().ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return users;
        }

    }
}
