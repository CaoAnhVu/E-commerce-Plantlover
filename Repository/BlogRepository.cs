using Cs_Plantlover.Models;
using Data;
using Repository.IRepository;

namespace Cs_Plantlover.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly DoAnWebDbContext _context;
        public BlogRepository(DoAnWebDbContext context)
        {
            _context = context;
        }

        public BlogDetail Add(BlogDetail blog)
        {
            _context.BlogDetails.Add(blog);
            _context.SaveChanges();
            return blog;
        }

        public BlogDetail Delete(BlogDetail id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogDetail> GetAllBlogDetail()
        {
            return _context.BlogDetails;

        }

        public BlogDetail GetBlogDetail(int id)
        {
            return _context.BlogDetails.Find(id);
        }

        public BlogDetail Update(BlogDetail blog)
        {
            _context.Update(blog);
            _context.SaveChanges();
            return blog;
        }
    }
}
