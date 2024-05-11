using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models
{
    public class LeaveMessenger
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string? FullName { get; set; }
        [StringLength(100)]
        public string? Email {  get; set; }
        [StringLength(4000)]
        public string? Messenger {  get; set; }
    }
}
