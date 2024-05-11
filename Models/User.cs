using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cs_Plantlover.Models
{
   public class User : IdentityUser
    {
        [Required]
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Village { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? PhoneNumber { get; set; }
        [NotMapped]
        public string? Role { get; set; }
    }
}
