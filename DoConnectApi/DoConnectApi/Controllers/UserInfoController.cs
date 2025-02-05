using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DoConnectEntity;
using DoConnectRepository.Data;
using DoConnectService.UserInfo_Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DoConnectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        IUserInfoService _userInfoService;
        public IConfiguration _config;
        private readonly DoConnectDbContext _Context;
        ILogger<UserInfoController> _logger;

        public UserInfoController(IUserInfoService userInfoService, IConfiguration config, DoConnectDbContext Context, ILogger<UserInfoController> logger)
        {
            _userInfoService = userInfoService;
            _config = config;
            _Context = Context;
            _logger = logger;
        }

        [HttpPut ("Register")]
        public IActionResult Register([FromBody]UserInfo userInfo)
        {

            _userInfoService.Register(userInfo);
            object result = "User Registered Successfully";
            return Ok(result);
            //try
            //{
            //    _userInfoService.Register (userInfo);
            //    object result = "User Registered Successfully";
            //    return Ok(result);
            //}

            //catch (Exception ex)
            //{
            //    _logger.LogError(ex.Message);
            //    return StatusCode(500, "Internal server error");
            //}
        }

        [HttpPost("Login")]
        public IActionResult Login(string Email, string Password)
        {
            UserInfo usr = _userInfoService.Login(Email, Password);
            if (usr != null)
            {
                var res = (GenerateJSONWebToken(usr));
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("Logout")]
        public IActionResult Logout([FromBody] UserInfo userInfo)
        {
            try
            {
                _userInfoService.Logout(userInfo);
                return Ok("Logggedout Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");

            }

        }

        [HttpGet("List of All Users")]
        public IActionResult GetAll()
        {
            var result = _userInfoService.GetUserInfo();
            return Ok(result);
        }

        private string GenerateJSONWebToken(UserInfo userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Name),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim("UserID", userInfo.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
