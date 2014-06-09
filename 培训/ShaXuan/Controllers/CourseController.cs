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
    public class CourseController : Controller
    {
        //
        // GET: /Course/
		private BlogService blogService = new BlogService();

        public ActionResult Index(int? page, int id)
        {
			var blogs = blogService.GetBlogs(id).ToList();
			var pblogs = new Paginated<Blog>(blogs, page ?? 1, 10);

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
