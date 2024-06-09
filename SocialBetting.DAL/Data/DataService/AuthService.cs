using Microsoft.Win32;
using SocialBetting.DAL.DTOs;
using SocialBetting.DAL.Models;
using SocialBetting.DAL.Services.IDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBetting.DAL.Services.DataService
{
    public class AuthService : IAuthService
    {
        private readonly IGenericClass _service;
        public AuthService(IGenericClass service) 
        {
            _service = service;
        }
        public async Task<SignUpDto> SignUp(SignUpModel model)
        {
            await _service.SaveData("sp_CreateUser", new
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                HashPassword = model.Password,
                IsActive = true,
                IsEmailVerified = true,
                RegistrationType = "InApp"
            });
            return new SignUpDto();
        }
        public async Task<bool> CheckEmailExsistence(string email)
        {
            var response = await _service.LoadData<SignUpDto, dynamic>("sp_CheckEmailExsistence",
                new { email });

            if (!response.Any())
                return false;

            return true;
        }
        public async Task<LoginModel?> GetDataforAuth(string email, string password)
        {
            var result = await _service.LoadData<LoginModel, dynamic>(
                "sp_UserProfileLogin",
                new { Email = email, Password = password });

            return result.FirstOrDefault();
        }
        public async void UpdatePasswordOnEmail(string email, string password)
        {
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password)) return;

            await _service.LoadData<SignUpModelRequest, dynamic>(
                "sp_UpdatePasswordForgetEmail",
                new { Email = email, Password = password });

            return;
        }
        public async Task<GoogleUserDto?> GoogleSignInUser(string email, string name, string profilePicture, bool isEmailVerified, string? googleId)
        {
            var result = await _service.LoadData<GoogleUserDto, dynamic>("sp_GoogleSignInUser", new
            {
                Email = email,
                FirstName = name,
                ProfilePicture = profilePicture,
                IsEmailVerified = isEmailVerified,
                IsActive = true,
                RegistrationType = "External",
                GoogleId = googleId
            });
            return result.FirstOrDefault();
        }
        public async Task<AppleUserDto?> AppleSignInUser(string email, string name, string profilePicture, bool isEmailVerified, string? appleId)
        {
            var result = await _service.LoadData<AppleUserDto, dynamic>("sp_AppleSignInUser", new
            {
                Email = email,
                FirstName = name,
                ProfilePicture = profilePicture,
                IsEmailVerified = isEmailVerified,
                IsActive = true,
                RegistrationType = "External",
                AppleId = appleId
            });
            return result.FirstOrDefault();
        }
    }
}
