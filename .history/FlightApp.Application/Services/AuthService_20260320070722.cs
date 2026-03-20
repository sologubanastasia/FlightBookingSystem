using FlightApp.Application.Interfaces;
using FlightApp.Application.Interfaces;
using FlightApp.Application.Dto.Auth;
using FlightApp.Domain.Entities;
using FlightApp.Domain.Constants;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace FlightApp.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        public AuthService(UserManager<User> userManager, IJwtService jwtService, IMapper mapper)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            var user = new User { UserName = dto.Email, Email = dto.Email };
            var result = await _userManager.CreateAsync(user, dto.Password);
            
            if (!result.Succeeded) throw new Exception("Registration failed");

            await _userManager.AddToRoleAsync(user, UserRoles.User);
            
            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtService.GenerateToken(user, roles);

            return new AuthResponseDto(token, user.Email!);
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
                return null;

            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtService.GenerateToken(user, roles);

            return new AuthResponseDto(token, user.Email!);
        }
    }
}