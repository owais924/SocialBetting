using SocialBetting.CommonHelper.Middleware.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBetting.CommonHelper.Middleware.IService
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}
