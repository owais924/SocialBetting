using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBetting.DAL.Data.IDataService
{
    public interface IOtpService
    {
        int GenerateOTP();
        bool ValidateOTP(int otp);
    }
}
