using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hammer.Core.Models.Site;
using Hammer.Core.Services;
using Hammer.Common.Models;
using Hammer.Core.Models;

namespace ShaXuan.Controllers
{
    public class SkillController : Controller
    {
        //
        // GET: /Skill/
		private BlogService blogService = new BlogService();

        public ActionResult Index(int? page, int id)
        {
			var blogs = blogService.GetBlogs().Where(m => m.CategoryID == id).ToList();
			var pblogs = new Paginated<Blog>(blogs, page ?? 1, 12);
			ViewBag.Category = blogService.GetBlogCategory(id);

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
