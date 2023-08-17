using DemirorenProject.API.DbContexts;
using DemirorenProject.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DemirorenProject.API.Controllers
{
    [Route("api/Authentication")]
    [ApiController]
#pragma warning disable CS1591 // Genel olarak görülebilir tür veya üye için eksik XML açıklaması
    public class AuthenticationController : ControllerBase
#pragma warning restore CS1591 // Genel olarak görülebilir tür veya üye için eksik XML açıklaması
    {
        private IConfiguration _configuration;
        private readonly NewsContext _newsContext;
        public class AuthenticationRequestBody
        {
            public string? Username { get; set; }
            public string? Password { get; set; }
        }


        public AuthenticationController(IConfiguration config,NewsContext context)
        {
            _configuration = config ?? throw new ArgumentNullException(nameof(config));
            _newsContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {

            var user = ValidateUserCredentials(authenticationRequestBody.Username, authenticationRequestBody.Password);
            
            if (user == null) { return Unauthorized(); }

            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.UserId.ToString()));
            claimsForToken.Add(new Claim("given_name", user.FirstName));
            claimsForToken.Add(new Claim("family_name", user.LastName));
            claimsForToken.Add(new Claim("Role", user.Role));

            var jwtsecuritytoken = new JwtSecurityToken(
                _configuration["authentication:Issuer"],
                _configuration["authentication:Audience"],
                claimsForToken,DateTime.Now,
                DateTime.Now.AddHours(1),
                signingCredentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(jwtsecuritytoken);
            return Ok(jwt);
        }

        private UsersEN ValidateUserCredentials(string? username, string? password)
        {
            var user = _newsContext.Users.Where(p => p.UserName == username).FirstOrDefault();
            if (user == null) { return null; }
            if (user.Password != password) { return null; }

            return user;
        }

    }
}
