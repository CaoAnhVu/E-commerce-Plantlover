using Cs_Plantlover.Models;
using Data;
using Repository.IRepository;

namespace Cs_Plantlover.Repository
{
    public class ChucNangSPRepository : IChucNangSPRepository
    {
        private readonly DoAnWebDbContext _context;
        public ChucNangSPRepository(DoAnWebDbContext context)
        {
            _context = context;
        }

        public ChucNangSP Add(ChucNangSP chucnangSP)
        {
            _context.ChiTietSP.Add(chucnangSP);
            _context.SaveChanges();
            return chucnangSP;
        }

        public ChucNangSP Delete(ChucNangSP machucnangSP)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChucNangSP> GetAllChucNangSP()
        {
            return _context.ChiTietSP;

        }

        public ChucNangSP GetChucNangSP(int machucnangSP)
        {
            return _context.ChiTietSP.Find(machucnangSP);
        }

        public ChucNangSP Update(ChucNangSP chucnangSP)
        {
            _context.Update(chucnangSP);
            _context.SaveChanges();
            return chucnangSP; 
        }
    }
}
