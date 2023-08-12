using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBookWebAPI.Domain.Entity;
using PhoneBookWebAPI.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetUserSortController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<GetUsersController> _logger;

        public GetUserSortController(IUserService userService, ILogger<GetUsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public Task<List<User>> GetUsers(int limit = 10, bool sortByFIO = false, bool sortByBirthDay = false)
        {

            return _userService.GetUser(limit, sortByFIO, sortByBirthDay);
        }
    }
}
