using Data.Requests.User;
using Data.Responses;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<Response> Register(RegisterRequest request)
        {
            return await _userService.Register(request);
        }

        [HttpPost("login")]
        public async Task<Response> Login(LoginRequest request)
        {
            return await _userService.Login(request);
        }
    }
}
