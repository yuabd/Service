using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hammer.Core.Services;
using Hammer.Common.Models;
using Hammer.Core.Models;

namespace ShaXuan.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
    public class TeacherController : Controller
    {
        //
        // GET: /Admin/Teacher/
		private BlogService blogService = new BlogService();

        public ActionResult Index(int? page)
        {
			var blogs = blogService.GetBlogs().Where(m => m.BlogCategory.Slug == "师资队伍").ToList();
			var pblogs = new Paginated<Blog>(blogs, page ?? 1, 25);

			return View(pblogs);
        }

    }
}
