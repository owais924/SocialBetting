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
    }
}
