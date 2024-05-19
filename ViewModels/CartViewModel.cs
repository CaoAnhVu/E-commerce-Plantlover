 using Cs_Plantlover.Models;
using System;
using System.Collections.Generic;
using System.Text;
namespace Cs_Plantlover.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public OrderHeader OrderHeader { get; set; }
    }
}
