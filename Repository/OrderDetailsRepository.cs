using Data;
using Cs_Plantlover.Repository.IRepository;
using Cs_Plantlover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cs_Plantlover.Repository
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {

        private readonly DoAnWebDbContext _context;
        public OrderDetailsRepository(DoAnWebDbContext context)
        {
            _context = context;
        }
        public void Update(OrderDetails orderDetails)
        {
            _context.Update(orderDetails);
        }
    }    
}
