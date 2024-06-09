using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBetting.DAL.DTOs
{
    public class AppleUserDto
    {
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? ProfilePicture { get; set; }
        public bool IsEmailVerified { get; set; }
        public string? AppleId { get; set; }
    }
}
