using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hammer.Core.Services;
using Hammer.Common.Models;
using Hammer.Core.Models;

namespace ShaXuan.Controllers
{
    public class AboutController : Controller
    {
        //
        // GET: /Teacher/

		private BlogService blogService = new BlogService();

		public ActionResult Index()
		{
            var blog = blogService.GetBlog(645);

			return View(blog);
		}

		public ActionResult Teachers(int? page)
		{
			var blogs = blogService.GetBlogs().Where(m => m.CategoryID == 7).ToList();
			var pblogs = new Paginated<Blog>(blogs, page ?? 1, 9);

			return View(pblogs);
		}

		public ActionResult Detail(string id)
		{
			var blog = blogService.GetBlog(id);
			blog.PageVisits += 1;
			blogService.Save();

			return View(blog);
		}

		public ActionResult RongYu()
		{
			var blog = blogService.GetBlog("沙宣校史");

			return View(blog);
		}
    }
}
