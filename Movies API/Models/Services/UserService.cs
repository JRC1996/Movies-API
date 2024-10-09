using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Movies_API.Models.Common;
using Movies_API.Models.Response;
using Movies_API.Models.Viewmodels;
using Movies_API.Tools;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Movies_API.Models.Services
{
    
    public class UserService : IUserService
    {
        
        private readonly MoviesContext _context;
        private readonly AppSettings _appSettings;

        public UserService(MoviesContext context, IOptions<AppSettings> settings) 
        {
            _appSettings = settings.Value;
            _context = context;
        
        }

        public UserResponse Auth(AuthViewmodel model)
        {
            UserResponse userResponse = new UserResponse();

          

                var  spassword = Encrypt.GetSHA256(model.Password);
                var user = _context.Users.Where(u => u.Email == model.Email && u.Password == spassword).FirstOrDefault();

                if (user == null) return null;

                userResponse.Email = user.Email;
                userResponse.Token = GetToken(user);

           

            return userResponse;
        }


        private string GetToken(User user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.Email)

                    }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
