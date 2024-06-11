using Microsoft.Extensions.Configuration;
using SocialBetting.DAL.Data.IDataService;
using SocialBetting.DAL.Services.IDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBetting.CommonHelper.Service
{
    public class OtpService : IOtpService
    {
        private readonly IGenericClass _service;
        private readonly IConfiguration _configuration;
        public OtpService(IGenericClass genericClass, IConfiguration configuration) 
        {
            _service = genericClass;
            _configuration = configuration;
        }
         public int GenerateOTP()
         {
            Random random = new Random();
            GlobalAccessible.Otp = random.Next(1000, 10000);
            Timer timer = new Timer(_ =>
            {
                GlobalAccessible.Otp = 0;
            }, null, TimeSpan.FromMinutes(30), Timeout.InfiniteTimeSpan);
            return GlobalAccessible.Otp;
         }
       public bool ValidateOTP(int otp) =>
            GlobalAccessible.Otp.Equals(otp);

    }
    public static class GlobalAccessible
    {
        public static int Otp { get; set; }
    }
}
