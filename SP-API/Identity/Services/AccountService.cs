using Application.DTOs.User;
using Application.Enums;
using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Settings;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

namespace Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JWTSettings _jwtSettings;
        private readonly IDateTimeService _dateTime;

        public AccountService(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager,
            IOptions<JWTSettings> jwtSettings,
            IDateTimeService dateTime)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
            _dateTime = dateTime;
        }

        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new ApiException($"No existen registros con el email {request.Email}");
            }

            var result = await _signInManager.PasswordSignInAsync(
                user.UserName,
                request.Password,
                false,
                lockoutOnFailure:false);

            if (!result.Succeeded)
            {
                throw new ApiException($"Las credenciales ingresadas no son correctas");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateJWTToken(user);

            throw new NotImplementedException();
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
        {
            var userNameAlreadyExists = await _userManager.FindByNameAsync(request.UserName);
            if (userNameAlreadyExists != null)
            {
                throw new ApiException($"Ya existe el perfil con nombre de usuario {request.UserName}");
            }

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var userEmailAlreadyExists = await _userManager.FindByEmailAsync(request.Email);
            if (userEmailAlreadyExists != null)
            {
                throw new ApiException($"Ya existe el perfil con email {request.Email}");
            }
            else
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.Basic.ToString());
                    return new Response<string>(user.Id, message: $"El usuario {user.UserName} fue creado exitosamente");
                }
                else
                {
                    throw new ApiException($"{result.Errors}");
                }
            }
        }

        private Task<JwtSecurityToken> GenerateJWTToken(User user)
        {
            throw new NotImplementedException();
        }

    }
}
