using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }

        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime ShippingDate { get; set; }
        [Required]
        public long OrderTotal { get; set; }
        public string? TrackingNumber { get; set; }
        public string? Carrier { get; set; }
        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public string? TransactionId { get; set; }

        [Required(ErrorMessage = "Nhập số điện thoại")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Nhập họ tên")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Nhập số nhà, tên đường")]
        public string? StreetAddress { get; set; }

        [Required(ErrorMessage = "Nhập Phường/Xã")]
        public string? Village { get; set; }

        [Required(ErrorMessage = "Nhập Quận/Huyện")]
        public string? Quan { get; set; }


        [Required(ErrorMessage = "Nhập tên tỉnh (thành phố)")]
        public string? City { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
