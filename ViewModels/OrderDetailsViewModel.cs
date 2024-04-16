using System;
using System.Collections.Generic;
using System.Text;
using Cs_Plantlover.Models;

namespace Cs_Plantlover.ViewModels
{
    public class OrderDetailsViewModel
    {
        public OrderHeader orderHeader { get; set; }
        public IEnumerable<OrderDetails> orderDetails { get; set; }
    }
}
