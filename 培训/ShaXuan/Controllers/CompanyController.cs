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
    public class CompanyController : Controller
    {
        //
        // GET: /Company/

		private BlogService blogService = new BlogService();
		private SocialService galleryService = new SocialService();
        private LinkService ls = new LinkService();

        public ActionResult Index()
        {
            //ViewBag.FirstNews = blogService.GetBlogs(10).Where(m => m.IsPublic == true).FirstOrDefault();
            ViewBag.News = blogService.GetBlogs(10).Where(m => m.IsPublic == true).Take(10).ToList();
            ViewBag.TopCourse = blogService.GetBlogs(1).Where(m => m.IsPublic == true).Take(3).ToList();
            ViewBag.Course = blogService.GetBlogs(1).Where(m => m.IsPublic == true).Skip(3).Take(7).ToList();
            ViewBag.Links = ls.GetLinks().Where(m => m.IsEnable != "N").ToList();

            return View();
        }

		public ActionResult Sidebar()
		{
            ViewBag.Course = blogService.GetBlogs(1).Where(m => m.IsPublic == true).Take(6).ToList();
            ViewBag.News = blogService.GetBlogs(18).Where(m => m.IsPublic == true).Take(6).ToList();
			ViewBag.FuWu = blogService.GetBlogs(10).Where(m => m.IsPublic == true).Take(6).ToList();

			return View();
		}

		public ActionResult Contact()
		{
			var contact = new ContactViewModel();
			ViewBag.Contact = "current";

			return View(contact);
		}

		[HttpPost]
		public ActionResult Contact(ContactViewModel contact)
		{
			ViewBag.currentContact = "current";

			if (ModelState.IsValid)
			{
				Hammer.Common.Models.MessageTemplate template = new Hammer.Common.Models.MessageTemplate("/content/contact.htm");
				template.Set("ContactName", contact.ContactName);
				template.Set("Email", contact.Email);
				template.Set("Message", contact.Message);
				template.Set("SumCheck", contact.SumCheck);

				Hammer.Common.Models.MailBag mail = new Hammer.Common.Models.MailBag();

				mail.Message = template.Content;
				mail.Subject = template.Subject;
				mail.ToMailAddress = contact.Email;
				mail.Send(true);

				ViewBag.ThankYou = true;

				return View();
			}

			return View(contact);
		}

    }
}
