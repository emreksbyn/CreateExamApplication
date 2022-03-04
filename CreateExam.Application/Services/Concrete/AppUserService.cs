using AutoMapper;
using CreateExam.Application.Models.Dtos;
using CreateExam.Application.Services.Interface;
using CreateExam.Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CreateExam.Application.Services.Concrete
{
    public class AppUserService : IAppUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AppUserService(IMapper mapper,
                              UserManager<AppUser> userManager,
                              SignInManager<AppUser> signInManager)
        {
            this._mapper = mapper;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        public async Task<SignInResult> Login(LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            return result;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterDto model)
        {
            var user = _mapper.Map<AppUser>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }
    }
}