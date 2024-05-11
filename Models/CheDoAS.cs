using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models
{
    public class CheDoAS
    {
        [Key ,Required]
        public int MaCheDoAS {  get; set; }

        [Required,StringLength(150)]
        public string? TenCheDoAS { get; set; }
        public virtual ICollection<DanhMucSP> DanhMucSPs { get; set; } = new List<DanhMucSP>();
    }
}
