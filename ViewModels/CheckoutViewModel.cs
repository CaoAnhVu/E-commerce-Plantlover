using Cs_Plantlover.Models;
using System;
using System.Collections.Generic;
using System.Text;
namespace Cs_Plantlover.ViewModels
{
    public class CheckoutViewModel
    {
        public Cart Cart { get; set; }
        public User User { get; set; }
        // Thêm thuộc tính cho phương thức thanh toán
        public string PaymentMethod { get; set; }

    }
}
