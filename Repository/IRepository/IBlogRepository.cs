using Cs_Plantlover.Models;
namespace Repository.IRepository
{
    public interface IBlogRepository
    {
        BlogDetail Add(BlogDetail blog);
        BlogDetail Update(BlogDetail blog);
        BlogDetail Delete(BlogDetail id);
        BlogDetail GetBlogDetail(int id);
        IEnumerable<BlogDetail> GetAllBlogDetail();
    }
}
