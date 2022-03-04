using CreateExam.Application.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CreateExam.Application.Services.Interface
{
    public interface IAppUserService
    {
        Task<IdentityResult> Register(RegisterDto model);
        Task<SignInResult> Login(LoginDto model);
        Task LogOut();
    }
}