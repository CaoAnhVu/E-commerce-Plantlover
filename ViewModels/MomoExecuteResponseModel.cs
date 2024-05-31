namespace Cs_Plantlover.Models.Momo;

public class MomoExecuteResponseModel
{
    public int OrderId { get; set; }
    public string FullName { get; set; }
    public string Description { get; set; }
    public double Amount { get; set; }
    public DateTime CreatedDate { get; set; }
}