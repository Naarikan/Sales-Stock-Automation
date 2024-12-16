using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Blazor.API.ViewModels.Login;
using Blazor.BLL.Managers.Abstract;
using Blazor.Entities.Security;
using Microsoft.IdentityModel.Tokens;
using NETCore.Encrypt;

namespace Blazor.API.Security
{
	public class AuthService:IAuthService
    {
        IEmployeeManager _empmanager;
        IConfiguration _configuration;
        IUserRoleManager _rolemanager;
        public AuthService(IEmployeeManager empmanager, IConfiguration configuration, IUserRoleManager rolemanager)
        {
            _empmanager = empmanager;
            _configuration = configuration;
            _rolemanager = rolemanager;
        }

        public async Task<LoginResponseModel> LoginAsync(LoginRequestModel model)
        {
            Token token = new();
            string sha256salt = _configuration.GetValue<string>("AppSettings:SHA256SALT");
            string Password = model.Password + sha256salt;
            string hashedPassword = EncryptProvider.Sha256(Password);
            var employee = await _empmanager.FilterFirstOrDefaultAsync(x => x.Email == model.Email && x.PasswordHash == hashedPassword);
           
            if (employee == null) { return null; }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,employee.Email),
                new Claim(ClaimTypes.Name,employee.FirstName),
                new Claim ("Id",employee.Id.ToString())
            };

            var userRoles = await _rolemanager.GetUserRolesAsync(employee.Id);
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role,userRole));

            }



             token.AccessToken = GenerateJsonWebToken(authClaims);

            LoginResponseModel loginResponseModel = new LoginResponseModel()
            {
              
                Token = token
            };

            return loginResponseModel;
        }




        private string GenerateJsonWebToken(List<Claim> claims)
        {
            var authkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var tokenObject = new JwtSecurityToken(
                issuer:_configuration["Jwt:Issuer"],
                audience:_configuration["Jwt:Audience"],
                expires:DateTime.Now.AddDays(1),
                claims:claims,
                signingCredentials:new SigningCredentials(authkey,SecurityAlgorithms.HmacSha256)
                
                );
            string token=new JwtSecurityTokenHandler().WriteToken(tokenObject);
            return token;
        }

    }
}
