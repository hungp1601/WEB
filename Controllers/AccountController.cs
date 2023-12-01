using Microsoft.AspNetCore.Mvc;
using NHNT.Dtos;
using NHNT.Services;

namespace NHNT.Controllers
{
    [Route("[controller]")]
    public class AccountController : ControllerCustom
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromForm] string username, [FromForm] string password)
        {
            return Ok(_userService.Login(username, password));
        }

        [HttpPost("[action]")]
        public IActionResult RefreshToken([FromForm] string accessToken, [FromForm] string refreshToken)
        {
            return Ok(_userService.RefreshToken(accessToken, refreshToken));
        }

        [HttpGet("[action]")]
        public IActionResult RegisterForm()
        {
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult Register([FromForm] UserDto dto)
        {
            return Ok(_userService.Register(dto));
        }
    }
}