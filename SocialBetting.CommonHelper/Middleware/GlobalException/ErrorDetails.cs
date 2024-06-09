﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBetting.CommonHelper.Middleware.GlobalException
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Status
        {
            get
            {
                return Enum.GetName(typeof(ResponseMessages)!, ResponseMessages.Error)!;
            }
        }
        public string Message { get; set; }
        public string InnerMessage { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public ErrorDetails()
        {

        }

        public ErrorDetails(int StatusCode, string Message, string InnerMessage)
        {
            this.StatusCode = StatusCode;
            this.Message = Message;
            this.InnerMessage = InnerMessage;
        }
    }
    public enum ResponseMessages
    {
        Success,
        Failure,
        Error
    }
}
