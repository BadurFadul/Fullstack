using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApi.Business.Src.Abstractions;
using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;

namespace WebApi.Business.Src.Shared
{
    public class AuthService: IAuthService
    {
        private readonly IUserRepo _userRepo;
        private readonly string _jwtSecretKey;

         public AuthService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
            //_jwtSecretKey = jwtSecretKey;
        }
        public async Task<string> VerifyCredentials(UserCredentialDto credentials)
        {
            var foundUserByEmail = await _userRepo.FindOneByEmail(credentials.Email);
            if (foundUserByEmail == null) throw new Exception("Email not found");
            var isAuthenticated = PasswordService.VerifyPassword(credentials.Password, foundUserByEmail.Password, foundUserByEmail.Salt);
            if(!isAuthenticated)
            {
                throw new Exception("Credentials are wrong.");
            }
            return GenerateToken(foundUserByEmail);
        }

        private string GenerateToken(User user)
        {
            var Claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToString())
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my-secrete-key-jwt-token-validator"));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var JwtSecurityDescriptor = new SecurityTokenDescriptor{
                Issuer = "Ecommerce-backend",
                Expires = DateTime.Now.AddMinutes(40),
                Subject = new ClaimsIdentity(Claims),
                SigningCredentials = signingCredentials
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.CreateToken(JwtSecurityDescriptor);
            return jwtSecurityTokenHandler.WriteToken(token);
        }
    }
}
