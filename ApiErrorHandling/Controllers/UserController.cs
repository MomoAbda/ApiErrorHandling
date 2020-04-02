using System.Collections.Generic;
using ApiErrorHandling.Models;
using ApiErrorHandling.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiErrorHandling.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRandomApiService _randomApiService;
        private readonly ILogger<UserController> _logger;
        public UserController(IRandomApiService randomApiService, ILogger<UserController> logger)
        {
            _randomApiService = randomApiService;
        }

        [HttpGet]
        public UserInformations Get([FromQuery] int idUser)
        {
            return _randomApiService.GetRandomUserInformation(idUser);
        }
    }
}
