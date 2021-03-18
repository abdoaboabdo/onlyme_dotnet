using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlyMe.DAL.Context;
using OnlyMe.DAL.Entities;
using OnlyMe.DAL.Models.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlyMe.Services.Services.UsersService
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly OnlyMeDBContext _dbContext;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            OnlyMeDBContext dbContext,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<IdentityResult> Regiser(UserRegisterVM model, bool isPersistent = false)
        {
            // Map;
            var user = new ApplicationUser
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName,
                Email = model.Email,
                EmailConfirmed = true
            };

            var identityResult = await _userManager.CreateAsync(user, model.Password);
            if (identityResult.Succeeded)
            {
                return identityResult;
            }
            var identityError = new IdentityError();
            identityError.Code = "400";
            identityError.Description = "Faild to Register";
            return IdentityResult.Failed(identityError);
        }
        public async Task<SignInResult> LogIn(UserLoginVM model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);
            if (!result.Succeeded)
            {
                return null;
            }
            return result;
        }

        public RerurnToken CreateToken(UserLoginVM model)
        {
            var user = _dbContext.Users.SingleOrDefault(user => user.UserName == model.UserName);
            string key = _configuration.GetSection("JwtConfig").GetSection("secret").Value; //Secret key which will be used later during validation    
            var issuer = "http://localhost:5463";  //normally this will be your site URL    

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //Create a List of Claims, Keep claims name short    
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, user.Id));
            permClaims.Add(new Claim("valid", "1"));
            permClaims.Add(new Claim("Id", user.Id));
            permClaims.Add(new Claim("UserName", user.UserName));
            permClaims.Add(new Claim("Email", user.Email));
            permClaims.Add(new Claim("Name", user.Name));
            permClaims.Add(new Claim(ClaimTypes.Role, "SuperAdmin"));

            //Create Security Token object by giving required parameters    
            var token = new JwtSecurityToken(issuer, //Issure    
                            issuer,  //Audience    
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);

            return new RerurnToken { Token = jwt_token, Expires = DateTime.Now.AddDays(1) };
        }
    }

    public class RerurnToken
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
