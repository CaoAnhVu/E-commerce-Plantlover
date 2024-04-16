using Data;
using Cs_Plantlover.Repository.IRepository;
using Cs_Plantlover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cs_Plantlover.Repository
{
    public class ChiTietSPRepository :  IChiTietSPRepository
    {
        private readonly DoAnWebDbContext _context;
        public ChiTietSPRepository(DoAnWebDbContext context)
        {
            _context = context;
        }

        public void Update(ChiTietSP chiTietSP)
        {
            var objFromDb = _context.ChiTietSps.FirstOrDefault(s => s.MaChiTietSP == chiTietSP.MaChiTietSP);
            if (objFromDb != null)
            {
                objFromDb.MaSP = chiTietSP.MaSP;
                objFromDb.HinhAnh = chiTietSP.HinhAnh;
                objFromDb.DonGiaBan = chiTietSP.DonGiaBan;
                objFromDb.GiamGia = chiTietSP.GiamGia;
                objFromDb.GiaBan = chiTietSP.GiaBan;
                objFromDb.SoLuong = chiTietSP.SoLuong;
            }
        }
    }
}
