using Data;
using Cs_Plantlover.Repository.IRepository;
using Cs_Plantlover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cs_Plantlover.Repository
{
    public class DanhMucSanPhamRepository : IDanhMucSanPhamRepository
    {
        private readonly DoAnWebDbContext _context;
        public DanhMucSanPhamRepository(DoAnWebDbContext context)
        {
            _context = context;
        }

        public void Update(DanhMucSP danhMucSP)
        {
            var objFromDb = _context.DanhMucSps.FirstOrDefault(s => s.MaSP == danhMucSP.MaSP);
            if(objFromDb != null)
            {
                if(danhMucSP.AnhDaiDien != null)
                {
                    objFromDb.AnhDaiDien = danhMucSP.AnhDaiDien;
                }

                objFromDb.TenSP = danhMucSP.TenSP;
                objFromDb.MaChucNang = danhMucSP.MaChucNang;
                objFromDb.MaCheDoAS = danhMucSP.MaCheDoAS;
                objFromDb.MaKichThuoc = danhMucSP.MaKichThuoc;
                objFromDb.MaMoiTruongSong = danhMucSP.MaMoiTruongSong;
                objFromDb.MaViTri = danhMucSP.MaViTri;
                objFromDb.MoTa = danhMucSP.MoTa;
                objFromDb.AnhDaiDien = danhMucSP.AnhDaiDien;
                objFromDb.GiaBan = danhMucSP.GiaBan;
            }
        }
    }
}
