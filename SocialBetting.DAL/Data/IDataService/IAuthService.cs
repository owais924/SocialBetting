using SocialBetting.DAL.DTOs;
using SocialBetting.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBetting.DAL.Services.IDataService
{
    public interface IAuthService
    {
        Task<SignUpDto> SignUp(SignUpModel model);
        Task<bool> CheckEmailExsistence(string email);
        Task<LoginModel?> GetDataforAuth(string email, string password);
        void UpdatePasswordOnEmail(string email, string password);
        Task<GoogleUserDto?> GoogleSignInUser(string email, string name, string profilePicture, bool isEmailVerified, string? googleId);
        Task<AppleUserDto?> AppleSignInUser(string email, string name, string profilePicture, bool isEmailVerified, string? appleId);
    }
}
