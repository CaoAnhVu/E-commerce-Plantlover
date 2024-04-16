using Data;
using Cs_Plantlover.Repository.IRepository;
using Cs_Plantlover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cs_Plantlover.Repository.IRepository
{
    public class OrderHeaderRepository: IOrderHeaderRepository
    {
        private readonly DoAnWebDbContext _context;
        public OrderHeaderRepository(DoAnWebDbContext context)
        {
            _context = context;
        }
        public void Update(OrderHeader orderHeader)
        {
            _context.Update(orderHeader);
        }
    }
}
