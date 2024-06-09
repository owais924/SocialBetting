using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBetting.DAL.Models
{
    public class AppleAuthModel
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public bool IsEmailVerified { get; set; }
        public string? AppleId { get; set; }
    }
}
