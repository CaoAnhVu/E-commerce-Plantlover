using Data;
using Cs_Plantlover.Repository.IRepository;
using Cs_Plantlover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cs_Plantlover.Migrations;
using System.Linq.Expressions;

namespace Cs_Plantlover.Repository
{
    public class CartRepository : IChiTietSPRepository
    {
        private readonly DoAnWebDbContext _context;
        public CartRepository(DoAnWebDbContext context)
        {
            _context = context;
        }


        public void Update(ChiTietSP chiTietSP)
        {
            _context.Update(chiTietSP);
        }
    }
}
