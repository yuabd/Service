using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hammer.Common.Models;
using Hammer.Core.Services;
using Hammer.Core.Models;

namespace ShaXuan.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/
		private BlogService blogService = new BlogService();

        public ActionResult Index(int? page)
        {
            var blogs = blogService.GetBlogs().Where(m => m.CategoryID == 18 && m.IsPublic == true).ToList();
			var pblogs = new Paginated<Blog>(blogs, page ?? 1, 8);

			return View(pblogs);
        }

		public ActionResult Notice(int? page)
		{
			var blogs = blogService.GetBlogs().Where(m => m.CategoryID == 10 && m.IsPublic == true).ToList();
			var pblogs = new Paginated<Blog>(blogs, page ?? 1, 8);

			return View(pblogs);
		}

		public ActionResult Detail(int id)
		{
			var blog = blogService.GetBlog(id);
			blog.PageVisits += 1;
			blogService.Save();
			ViewBag.Prv = blogService.GetPrvNextBlogID(id);

			return View(blog);
		}
    }
}
