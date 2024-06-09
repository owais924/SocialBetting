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
                FirstName= model.FirstName,
                LastName= model.LastName,
                Email= model.Email,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                IsActive =true,
                IsEmailVerified=true
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
    }
}
