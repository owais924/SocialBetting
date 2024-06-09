﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBetting.CommonHelper.Middleware.Class
{
    public class APIException : Exception
    {
        public APIException()
        {
        }

        public APIException(string message) : base(message)
        {
        }

        public APIException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
