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
    public class GalleryController : Controller
    {
        //
        // GET: /Gallery/

		SocialService socialService = new SocialService();
        public ActionResult Index(int? page,int id=2)
        {
			var blogs = socialService.GetGalleries().ToList();
			var pblogs = new Paginated<Gallery>(blogs, page ?? 1, 12);

			return View(pblogs);
        }

		public ActionResult GalleryDetail(int id)
		{
			var gallery = socialService.GetGallery(id);

			return View(gallery);
		}

		public ActionResult Videos(int? page)
		{
			var videos = socialService.GetVideos().ToList();
			var pvideos = new Paginated<Video>(videos, page ?? 1, 9);

			return View(pvideos);
		}

    }
}
