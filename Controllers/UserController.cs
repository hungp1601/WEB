
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NHNT.Constants;
using NHNT.Services;

namespace NHNT.Controllers
{
    public class UserController : ControllerCustom
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        } 

        [Authorize(RoleConfig.ADMIN)]
        [HttpGet("[controller]/[action]/{id}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            return Ok(_userService.GetUserById(id));
        }

        [Authorize]
        [HttpGet("[controller]/[action]")]
        public IActionResult GetCurrent()
        {
            string username = GetUsernameFromToken();
            return Ok(_userService.GetUserByUsername(username));
        }
    }
}