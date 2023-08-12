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
    
    public class GetUsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<GetUsersController> _logger;

        public GetUsersController(IUserService userService, ILogger<GetUsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
    /*
        [HttpGet]
        [Authorize]
        public Task<List<User>> GetUsersAll()
        {
            return _userService.GetUsers();
        }*/
    }
}
