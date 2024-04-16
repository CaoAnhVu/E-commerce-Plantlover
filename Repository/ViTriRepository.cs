using Cs_Plantlover.Models;
using Data;
using Repository.IRepository;

namespace Cs_Plantlover.Repository
{
    public class ViTriRepository : IViTriRepository
    {
        private readonly DoAnWebDbContext _context;
        public ViTriRepository(DoAnWebDbContext context)
        {
            _context = context;
        }
        public ViTri Add(ViTri viTri)
        {
            _context.ViTris.Add(viTri);
            _context.SaveChanges();
            return viTri;
        }

        public ViTri Delete(ViTri maviTri)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ViTri> GetAllViTri()
        {
            return _context.ViTris;
        }

        public ViTri GetViTri(int maviTri)
        {
            return _context.ViTris.Find(maviTri);
        }

        public ViTri Update(ViTri viTri)
        {
            _context.Update(viTri);
            _context.SaveChanges();
            return viTri;
        }
    }
}
