using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBetting.DAL.ViewModel
{
    public class AuthResponse
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public bool IsActive { get; set; }
    }
}
