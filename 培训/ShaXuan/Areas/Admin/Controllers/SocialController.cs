using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hammer.Core.Models;
using Hammer.Core.Services;
using Hammer.Common.Models;
using System.Web.Script.Serialization;

namespace ShaXuan.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
    public class SocialController : Controller
    {
        private SocialService socialService = new SocialService();

        //
        // GET: /Admin/Social/

		public ActionResult Videos()
		{
			var videos = socialService.GetVideos();

			return View(videos);
		}

		public ActionResult AddVideo()
		{
			Video video = new Video();
			video.DateTaken = DateTime.Today;
			video.IsPublic = true;

			return View(video);
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult AddVideo(Video video, HttpPostedFileBase file)
		{
			if (ModelState.IsValid)
			{
				socialService.InsertVideo(video, file);
				socialService.Save();

				return RedirectToAction("Videos");
			}

			return View(video);
		}

		public ActionResult EditVideo(int id)
		{
			var video = socialService.GetVideo(id);

			return View(video);
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult EditVideo(Video video, HttpPostedFileBase file)
		{
			if (ModelState.IsValid)
			{
				socialService.UpdateVideo(video, file);
				socialService.Save();

				return RedirectToAction("Videos");
			}

			return View(video);
		}

		public ActionResult DeleteVideo(int id)
		{
			socialService.DeleteVideo(id);
			socialService.Save();

			return RedirectToAction("Videos");
		}


        //Gallery

        public ActionResult Galleries()
        {
            var galleries = socialService.GetGalleries();

            return View(galleries);
        }

        public ActionResult AddGallery()
        {
            var gallery = new Gallery();
            gallery.DateTaken = DateTime.Today;
            gallery.IsPublic = true;

            return View(gallery);
        }

        [HttpPost]
        public ActionResult AddGallery(Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                socialService.InsertGallery(gallery);
                socialService.Save();
                var folder = Server.MapPath("/") + gallery.PictureFolder;
                if (!System.IO.Directory.Exists(folder))
                {
                    System.IO.Directory.CreateDirectory(folder);
                }

                return RedirectToAction("EditGallery", new { id = gallery.GalleryID });
            }

            return View(gallery);
        }

        public ActionResult EditGallery(int ID)
        {
            var gallery = socialService.GetGallery(ID);

            return View(gallery);
        }

        [HttpPost]
        public ActionResult EditGallery(Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                socialService.UpdateGallery(gallery);
                socialService.Save();
                
                return RedirectToAction("Galleries");
            }

            return View(gallery);
        }

        public ActionResult DeleteGallery(int id)
        {
            socialService.DeleteGallery(id);
            socialService.Save();

            return RedirectToAction("Galleries");
        }

        public ActionResult GalleryDetails(int id)
        {
            var gd = socialService.GetGalleryDetails(id).ToList();
            var g = socialService.GetGallery(id);
            ViewBag.GalleryID = id;
            ViewBag.GalleryName = g.GalleryName;

            return View(gd);
        }

        [HttpPost]
        public ActionResult AddGalleryDetail(GalleryDetail galleryDetail, HttpPostedFileBase file)
        {
            if (file != null)
            {
                socialService.InsertGalleryDetail(galleryDetail, file);
                socialService.Save();
            }
            return RedirectToAction("GalleryDetails", new { id = galleryDetail.GalleryID });
        }

        [HttpPost]
        public ActionResult EditGalleryDetail(GalleryDetail galleryDetail, HttpPostedFileBase file)
        {
            if (file != null)
            {
                var gd = socialService.GetGalleryDetail(galleryDetail.GalleryID, galleryDetail.PictureFile);
                socialService.DeleteGalleryDetail(gd);
                socialService.InsertGalleryDetail(galleryDetail, file);
                socialService.Save();
            }
            else
            {
                //socialService.UpdateGalleryDetail(galleryDetail, file);
                socialService.UpdateGalleryDetail(galleryDetail);
                socialService.Save();
            }

            
            
            return RedirectToAction("GalleryDetails", new { id = galleryDetail.GalleryID });
        }

        public ActionResult DeleteGalleryDetail(int id, string file)
        {
            var galleryDetail = socialService.GetGalleryDetail(id, file);
            socialService.DeleteGalleryDetail(galleryDetail);
            socialService.Save();

            return RedirectToAction("GalleryDetails", new { id = id });
        }

		public ActionResult UploadPicture(HttpPostedFileBase filedata)
		{
			xheditorModel model = new xheditorModel();

			if (filedata.ContentLength > 0)
			{
				var fileName = filedata.FileName;
				Hammer.Common.IO.UploadImageFile(filedata.InputStream, "/Content/Pictures/Social", fileName, 720);

				model.msg = "/Content/Pictures/Social/" + fileName;
			}

			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			return this.Content(javaScriptSerializer.Serialize(model));
		}
    }
}
