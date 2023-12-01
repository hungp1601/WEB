using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NHNT.Utils;
using NHNT.Models;

namespace NHNT.Controllers
{
    public class ControllerCustom : Controller
    {
        protected string GetUsernameFromToken()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            ClaimsPrincipal claimsPrincipal = jwtSecurityTokenHandler.ValidateToken(token, TokenUtils.GetTokenValidationParameters(), out securityToken);

            return claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "username").Value;
        }

        protected UserPartial GetUserPartial()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            return TokenUtils.DecodeJwtToken(token);
        }
    }
}