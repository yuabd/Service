using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Hammer.Core.Services;
using Hammer.Common.Models;
using Hammer.Core.Models;
using Hammer.Core.Models.Admin;

namespace ShaXuan.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
		private BlogService blogService = new BlogService();

		//
		// GET: /Admin/Blog/

		public ActionResult Index(int? page, int id)
		{
			var blogs = blogService.GetBlogs().Where(m => m.CategoryID == id).ToList();
			var pblogs = new Paginated<Blog>(blogs, page ?? 1, 25);
			ViewBag.CategoryID = id;

			return View(pblogs);
		}

		public ActionResult Add(int id)
		{
			var blog = new Blog();
			blog.AuthorID = User.Identity.Name;
			blog.DateCreated = DateTime.Now;
			blog.CategoryID = id;
			blog.IsPublic = true;

			IEnumerable<BlogTag> blogTags = null;

			var model = new BlogViewModel(blog, blogTags);

			return View(model);
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Add(Blog blog, IEnumerable<BlogTag> blogTags)
		{
			if (ModelState.IsValid)
			{
				HttpPostedFileBase file = Request.Files["PictureFile"];

				if (string.IsNullOrEmpty(blog.MetaKeywords))
				{
					foreach (var tag in blogTags)
					{
						if (!string.IsNullOrEmpty(tag.Tag))
							blog.MetaKeywords += tag.Tag + ",";
					}
				}

				blogService.InsertBlog(blog, file);
				blogService.Save();

				blogService.SaveBlogTags(blog, blogTags);

				return RedirectToAction("Edit", new { id = blog.BlogID });
			}
			else
			{
				var model = new BlogViewModel(blog, blogTags);
				return View(model);
			}
		}

		public ActionResult Edit(int id)
		{
			var blog = blogService.GetBlog(id);
			var blogTags = blogService.GetBlogTags(id);

			var model = new BlogViewModel(blog, blogTags);

			return View(model);
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Edit(Blog blog, IEnumerable<BlogTag> blogTags)
		{
			if (ModelState.IsValid)
			{
				HttpPostedFileBase file = Request.Files["PictureFile"];

				if (string.IsNullOrEmpty(blog.MetaKeywords))
				{
					foreach (var tag in blogTags)
					{
						if (!string.IsNullOrEmpty(tag.Tag))
							blog.MetaKeywords += tag.Tag + ",";
					}
				}

				blogService.UpdateBlog(blog, file);
				blogService.SaveBlogTags(blog, blogTags);
				blogService.Save();

				return RedirectToAction("Index", new { id = blog.CategoryID });
			}
			else
			{
				var model = new BlogViewModel(blog, blogTags);
				return View(model);
			}
		}

		public ActionResult Delete(int id)
		{
			var blog = blogService.GetBlog(id);
			blogService.DeleteBlog(id);
			blogService.Save();

			return RedirectToAction("Index", new { id = blog.CategoryID });
		}

		//
		// Comments

		public ActionResult PendingComments()
		{
			var blogs = blogService.GetBlogsWithPendingComments().ToList();
			return View(blogs);
		}

		// TODO: is this being used?
		[HttpPost]
		public string AddComment(BlogComment comment)
		{
			if (ModelState.IsValid)
			{
				blogService.InsertBlogComment(comment);
				blogService.Save();

				return "Thank you for your comment";
			}
			else
			{
				return "Error";
			}
		}

		public ActionResult ApproveComment(int id)
		{
			blogService.ApproveBlogComment(id);
			return RedirectToAction("PendingComments");
		}

		public ActionResult DeleteComment(int id)
		{
			blogService.DeleteBlogComment(id);
			blogService.Save();

			return RedirectToAction("PendingComments");
		}

		//
		// GET: /Admin/Blog/Categories

		public ActionResult Categories()
		{
			var categories = blogService.GetBlogCategories().ToList();

			return View(categories);
		}

		[HttpPost]
		public ActionResult Categories(BlogCategory category)
		{
			if (ModelState.IsValid)
			{
				if (category.CategoryID > 0)
				{
					blogService.UpdateBlogCategory(category);
					blogService.Save();
				}
				else
				{
					blogService.InsertBlogCategory(category);
					blogService.Save();
				}

				return RedirectToAction("Categories");
			}
			else
			{
				return RedirectToAction("Categories");
			}
		}

		public ActionResult DeleteCategory(int id)
		{
			blogService.DeleteBlogCategory(id);
			blogService.Save();

			return RedirectToAction("Categories");
		}

		public ActionResult UploadPicture(HttpPostedFileBase filedata)
		{
			xheditorModel model = new xheditorModel();

			if (filedata.ContentLength > 0)
			{
				var guid = Guid.NewGuid();
				var fileName = guid + filedata.FileName;
				Hammer.Common.IO.UploadImageFile(filedata.InputStream, "/Content/Pictures/Blog", fileName, 720);

				model.msg = "/Content/Pictures/Blog/" + fileName;
			}

			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			return this.Content(javaScriptSerializer.Serialize(model));
		}
    }
}
