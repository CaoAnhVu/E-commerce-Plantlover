using Cs_Plantlover.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
namespace Cs_Plantlover.ViewComponents
{
    public class BlogMenuViewComponent : ViewComponent
    {
        private readonly IBlogRepository _blog;
        public BlogMenuViewComponent(IBlogRepository blogRepository)
        {
            _blog = blogRepository;
        }
        public IViewComponentResult Invoke()
        {
            var blog = _blog.GetAllBlogDetail().OrderBy(x => x.Id);
            return View(blog);
        }

    }
}
