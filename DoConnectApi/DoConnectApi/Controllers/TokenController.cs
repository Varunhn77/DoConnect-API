using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DoConnectEntity;
using DoConnectRepository.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DoConnectApi.Controllers
{
    //public class TokenController : ControllerBase
    //{
    //    public IConfiguration _configuration;
    //    private readonly DoConnectDbContext _context;

    //    public TokenController(IConfiguration config, DoConnectDbContext context)
    //    {
    //        _configuration = config;
    //        _context = context;
    //    }

    //    [HttpPost("Login")]
    //    public async Task<IActionResult> Post(UserInfo _userData)
    //    {

    //        if (_userData != null && _userData.Email != null && _userData.Password != null)
    //        {
    //            var user = await GetUser(_userData.Email, _userData.Password);

    //            if (user != null)
    //            {
    //                //create claims details based on the user information
    //                var claims = new[] {
    //                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
    //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    //                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
    //                //new Claim("Id",user.Id),
    //                new Claim("Name", user.Name),
    //                new Claim("Description", user.Description),
    //               };

    //                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

    //                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

    //                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
    //            }
    //            else
    //            {
    //                return BadRequest("Invalid credentials");
    //            }
    //        }
    //        else
    //        {
    //            return BadRequest();
    //        }
    //    }

    //    private async Task<UserInfo> GetUser(string email, string password)
    //    {
    //        UserInfo userInfo = null;
    //        var result = _context.userInfo.Where(u => u.Email == email && u.Password == password);
    //        foreach (var item in result)
    //        {
    //            userInfo = new UserInfo(); //UserInfo -> In Repo
    //            userInfo.Id = item.Id;
    //            userInfo.Name = item.Name;
    //            userInfo.Description = item.Description;
    //            userInfo.Email = item.Email;
    //            userInfo.Mobile = item.Mobile;
    //        }
    //        return userInfo;

    //    }
    //}
    //public class TokenController : ControllerBase
    //{
    //    public IConfiguration _configuration;
    //    private readonly DoConnectDbContext _context;

    //    public TokenController(IConfiguration config, DoConnectDbContext context)
    //    {
    //        _configuration = config;
    //        _context = context;

    //    }
    //    [HttpPost("Register")]
    //    public async Task<IActionResult> Post(Product _userData)
    //    {

    //        if (_userData != null && _userData.Email != null && _userData.Password != null)
    //        {
    //            var user = await GetUser(_userData.Email, _userData.Password);

    //            if (user != null)
    //            {
    //                //create claims details based on the user information
    //                var claims = new[] {
    //             new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
    //             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    //             new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
    //             new Claim("Id", user.Id.ToString()),
    //             new Claim("Name", user.Name),
    //             new Claim("Description", user.Description),
    //             new Claim("Price", user.Price.ToString()),
    //            };

    //                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

    //                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

    //                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
    //            }
    //            else
    //            {
    //                return BadRequest("Invalid credentials");
    //            }
    //        }
    //        else
    //        {
    //            return BadRequest();
    //        }
    //    }

    //    private async Task<Product> GetUser(string email, string password)
    //    {
    //        Product userInfo = null;
    //        var result = _context.Products.Where(u => u.Email == email && u.Password == password);
    //        foreach (var item in result)
    //        {
    //            userInfo = new Product();
    //            userInfo.Id = item.Id;
    //            userInfo.Name = item.Name;
    //            userInfo.Description = item.Description;
    //            userInfo.Price = item.Price;

            
    //        }
    //        return userInfo;
    //        //return await _context.UserInfos.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    //    }

    //}
}
