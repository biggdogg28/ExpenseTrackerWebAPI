using AutoMapper.Execution;
using ExpenseTrackerWebAPI.Authentication;
using ExpenseTrackerWebAPI.DataContext;
using ExpenseTrackerWebAPI.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExpenseTrackerWebAPI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ExpenseTrackerDataContext _context;
        private readonly IConfiguration _configuration;
        public UserService(ExpenseTrackerDataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public AuthenticationResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.IdUser == model.Username && x.Username == model.Password);

            //return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticationResponse(user, token);
        }
        // helper methods
        private string generateJwtToken(Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Authentication:Secret")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration.GetValue<string>("Authentication:Domain"),
                _configuration.GetValue<string>("Authentication:Audience"),
                null,
                expires: DateTime.Now.AddDays(3),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
