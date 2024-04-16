using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public OrderHeader OrderHeader { get; set; }

        [Required]
        public int MaSP { get; set; }
        [ForeignKey("MaSP")]
        public DanhMucSP DanhMucSP { get; set; }

        public int Count { get; set; }
        public long Price { get; set; }
    }
}
