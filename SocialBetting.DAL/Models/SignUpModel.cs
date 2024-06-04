using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBetting.DAL.Models
{
    public class SignUpModel
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
