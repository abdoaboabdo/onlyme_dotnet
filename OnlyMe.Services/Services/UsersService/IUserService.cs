using Microsoft.AspNetCore.Identity;
using OnlyMe.DAL.Models.User;
using System.Threading.Tasks;

namespace OnlyMe.Services.Services.UsersService
{
    public interface IUserService
    {
        Task<IdentityResult> Regiser(UserRegisterVM model, bool isPersistent = false);
        Task<SignInResult> LogIn(UserLoginVM model);
        RerurnToken CreateToken(UserLoginVM model);
    }
}
