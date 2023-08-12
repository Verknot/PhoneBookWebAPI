using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBookWebAPI.DAL.Repository;
using PhoneBookWebAPI.Domain.Entity;
using PhoneBookWebAPI.Service.Implementations;
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
    public class GetUserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<GetUserController> _logger;


        public GetUserController(IUserService userService, ILogger<GetUserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        /*    [HttpGet]
            public Task<User> GetUser(long id)
            {

                return _userService.GetUser(id);
            }*/

        [HttpGet]
        [Authorize]
        public Task<User> GetUser(long id)
        {

            return _userService.GetUser(id);
        }
    }
}


