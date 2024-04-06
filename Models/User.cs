using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models
{
   public class User : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Age { get; set; }
    }
}
