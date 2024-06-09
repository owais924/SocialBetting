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
    }
}
