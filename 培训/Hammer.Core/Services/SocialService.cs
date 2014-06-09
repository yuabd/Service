using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hammer.Core.Models;

namespace Hammer.Core.Services
{
    public class SocialService
    {
        private SiteDataContext db = new SiteDataContext();

        //  CRUD

        //  Gallery

        public void InsertGallery(Gallery gallery)
        {
            if (string.IsNullOrEmpty(gallery.PageTitle))
            {
                gallery.PageTitle = Hammer.Common.Utilities.GenerateSlug(gallery.GalleryName, 50);
            }
            if (string.IsNullOrEmpty(gallery.Slug))
            {
                gallery.Slug = Hammer.Common.Utilities.GenerateSlug(gallery.GalleryName, 50);
            }

            db.Galleries.Add(gallery);
        }

        public Gallery GetGallery(int galleryID)
        {
            return db.Galleries.Find(galleryID);
        }

        public Gallery GetGallery(string slug)
        {
            return db.Galleries.SingleOrDefault(m => m.Slug == slug);
        }

        public void UpdateGallery(Gallery gallery)
        {
            var g = GetGallery(gallery.GalleryID);

            if (string.IsNullOrEmpty(gallery.PageTitle))
            {
                gallery.PageTitle = Hammer.Common.Utilities.GenerateSlug(gallery.GalleryName, 50);
            }
            if (string.IsNullOrEmpty(gallery.Slug))
            {
                gallery.Slug = Hammer.Common.Utilities.GenerateSlug(gallery.GalleryName, 50);
            }

            g.GalleryName = gallery.GalleryName;
            g.GalleryDescription = gallery.GalleryDescription;
            g.SortOrder = gallery.SortOrder;
            g.DateTaken = gallery.DateTaken;
            g.IsPublic = gallery.IsPublic;
            g.PageTitle = gallery.PageTitle;
            g.MetaDescription = gallery.MetaDescription;
            g.MetaKeywords = gallery.MetaKeywords;
            g.Slug = gallery.Slug;
        }

        public void DeleteGallery(int galleryID)
        {
            var g = GetGallery(galleryID);

            db.Galleries.Remove(g);
        }

        public IQueryable<Gallery> GetGalleries()
        {
            return db.Galleries.OrderBy(m => m.SortOrder).ThenByDescending(m => m.DateTaken);
        }

        //  Gallery Detail

        public void InsertGalleryDetail(GalleryDetail galleryDetail, HttpPostedFileBase file)
        {
            if (file != null)
            {
                UploadGalleryPicture(galleryDetail, file);
                db.GalleryDetails.Add(galleryDetail);
            }
        }

        public GalleryDetail GetGalleryDetail(int galleryID, string file)
        {
            return db.GalleryDetails.SingleOrDefault(m => m.GalleryID == galleryID && m.PictureFile == file);
        }

        public void UpdateGalleryDetail(GalleryDetail galleryDetail)
        {
            var gd = GetGalleryDetail(galleryDetail.GalleryID, galleryDetail.PictureFile);
            gd.PictureTitle = galleryDetail.PictureTitle;
            gd.SortOrder = galleryDetail.SortOrder;
        }

        public void DeleteGalleryDetail(GalleryDetail galleryDetail)
        {
            var gd = GetGalleryDetail(galleryDetail.GalleryID, galleryDetail.PictureFile);
            Hammer.Common.IO.DeleteFile(gd.PictureFolder, gd.PictureFile);

            db.GalleryDetails.Remove(gd);
        }

        public IQueryable<GalleryDetail> GetGalleryDetails(int galleryID)
        {
            return db.GalleryDetails.OrderBy(m => m.SortOrder).Where(m => m.GalleryID == galleryID);
        }

		//videos

		public void InsertVideo(Video video, HttpPostedFileBase file)
		{
			db.Videos.Add(video);
			Save();

			if (file != null)
			{
				UploadVideoPicture(video, file);
			}

			if (string.IsNullOrEmpty(video.PageTitle))
			{
				video.PageTitle = Hammer.Common.Utilities.GenerateSlug(video.VideoName, 50);
			}
			if (string.IsNullOrEmpty(video.Slug))
			{
				video.Slug = Hammer.Common.Utilities.GenerateSlug(video.VideoName, 50);
			}
		}

		public Video GetVideo(int videoID)
		{
			return db.Videos.Find(videoID);
		}

		public Video GetVideo(string slug)
		{
			return db.Videos.SingleOrDefault(m => m.Slug == slug);
		}

		public void UpdateVideo(Video video, HttpPostedFileBase file)
		{
			var v = GetVideo(video.VideoID);

			if (string.IsNullOrEmpty(video.PageTitle))
			{
				video.PageTitle = Hammer.Common.Utilities.GenerateSlug(video.VideoName, 50);
			}
			if (string.IsNullOrEmpty(video.Slug))
			{
				video.Slug = Hammer.Common.Utilities.GenerateSlug(video.VideoName, 50);
			}

			v.VideoName = video.VideoName;
			v.VideoDescription = video.VideoDescription;
			v.VideoCode = video.VideoCode;
			v.PageTitle = video.PageTitle;
			v.MetaDescription = video.MetaDescription;
			v.MetaKeywords = video.MetaKeywords;
			v.IsPublic = video.IsPublic;

			if (file != null)
			{
				UploadVideoPicture(v, file);
			}
		}

		public void DeleteVideo(int videoID)
		{
			var v = GetVideo(videoID);

			db.Videos.Remove(v);
		}

		public IQueryable<Video> GetVideos()
		{
			return db.Videos.OrderByDescending(m => m.DateTaken);
		}

		public void UploadVideoPicture(Video video, HttpPostedFileBase file)
		{
			string filename = string.Format("{0}-{1}", video.VideoName, file.FileName);

			Hammer.Common.IO.DeleteFile(video.PictureFolder, video.PictureFile);

			video.PictureFile = filename;

			Hammer.Common.IO.UploadImageFile(file.InputStream, video.PictureFolder, video.PictureFile, 215);
		}

        // Upload picture

        public void UploadGalleryPicture(GalleryDetail galleryDetail, HttpPostedFileBase file)
        {
            string filename = string.Format("{0}-{1}", galleryDetail.PictureTitle, file.FileName);
            // delete to overwrite
            Hammer.Common.IO.DeleteFile(galleryDetail.PictureFolder, galleryDetail.PictureFile);
            // update filename
            galleryDetail.PictureFile = filename;

            Hammer.Common.IO.UploadImageFile(file.InputStream, galleryDetail.PictureFolder, galleryDetail.PictureFile, 800);
        }

        //  others

        public void Save()
        {
            db.SaveChanges();
        }

		~SocialService()
		{
			db.Dispose();
		}
    }
}