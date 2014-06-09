using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Hammer.Core.Models;
using Hammer.Membership.Models;

namespace ShaXuan.Helpers
{
	public class ListHelper
	{
		public List<SelectListItem> GetRoleList()
		{
			using (Hammer.Membership.Models.SiteDataContext db = new Hammer.Membership.Models.SiteDataContext())
			{
				var list = from l in db.UserRoles.AsEnumerable()
						   orderby l.RoleID
						   select new SelectListItem { Value = l.RoleID.ToString(), Text = l.RoleID };

				return list.ToList();
			}
		}

		public List<Blog> GetBlogs(int id)
		{
			using (Hammer.Core.Models.SiteDataContext db = new Hammer.Core.Models.SiteDataContext())
			{
				var list = from l in db.Blogs.AsEnumerable()
						   where l.CategoryID == id
						   orderby l.SortOrder descending
						   select l;
				return list.ToList();
			}
		}

        public List<Blog> GetNewBlogs(int id)
        {
            using (Hammer.Core.Models.SiteDataContext db = new Hammer.Core.Models.SiteDataContext())
            {
                var list = from l in db.Blogs.AsEnumerable()
                           where l.CategoryID == id
                           orderby l.SortOrder descending
                           select l;

                return list.ToList();
            }
        }

		public List<Video> GetVideos()
		{
			using (Hammer.Core.Models.SiteDataContext db = new Hammer.Core.Models.SiteDataContext())
			{
				var list = from l in db.Videos.AsEnumerable()
						   select l;
				return list.ToList();
			}
		}

		public List<Gallery> GetGalleries()
		{
			using (Hammer.Core.Models.SiteDataContext db = new Hammer.Core.Models.SiteDataContext())
			{
				var list = from l in db.Galleries.AsEnumerable()
						   select l;
				return list.ToList();
			}
		}
		public List<SelectListItem> GetBlogCategoryList()
		{
			using (Hammer.Core.Models.SiteDataContext db = new Hammer.Core.Models.SiteDataContext())
			{
				var list = from l in db.BlogCategories.AsEnumerable()
						   where l.CategoryName != "公司介绍"
						   orderby l.CategoryName
						   select new SelectListItem { Value = l.CategoryID.ToString(), Text = l.CategoryName };

				return list.ToList();
			}
		}

		public List<BlogCategory> GetCategories()
		{
			using (Hammer.Core.Models.SiteDataContext db = new Hammer.Core.Models.SiteDataContext())
			{
				var list = from l in db.BlogCategories.AsEnumerable()
						   where l.CategoryName != "公司介绍"
						   select l;
				return list.ToList();
			}
		}

		public List<GalleryDetail> GetGalleryDetails()
		{
			using (Hammer.Core.Models.SiteDataContext db = new Hammer.Core.Models.SiteDataContext())
			{
				var list = from l in db.GalleryDetails.AsEnumerable()
						   where l.GalleryID==2
						   select l;
				return list.ToList();
			}
		}

		public List<Blog> GetBulletin()
		{
			using (Hammer.Core.Models.SiteDataContext db = new Hammer.Core.Models.SiteDataContext())
			{
				var list = from l in db.Blogs.AsEnumerable()
						   where l.CategoryID == 7
						   select l;
				return list.ToList();
			}
		}

		public List<SelectListItem> GetCourse()
		{
			using (Hammer.Core.Models.SiteDataContext db = new Hammer.Core.Models.SiteDataContext())
			{
				var list = from l in db.Blogs.AsEnumerable()
						   where l.CategoryID == 1 && l.IsPublic == true
                           orderby l.BlogID descending
						   select new SelectListItem { Text = l.BlogTitle, Value = l.BlogID.ToString() };
				return list.ToList();
			}
		}

        public List<SelectListItem> GetLinksEnable()
        {
            var list = new List<SelectListItem>();

            var item = new SelectListItem();
            item.Value = "Y";
            item.Text = "是";
            list.Add(item);
            var item1 = new SelectListItem();
            item1.Value = "N";
            item1.Text = "否";
            list.Add(item1);

            return list;
        }

        public List<SelectListItem> GetSex()
        {
            var list = new List<SelectListItem>();

            var item = new SelectListItem();
            item.Value = "男";
            item.Text = "男";
            list.Add(item);
            var item1 = new SelectListItem();
            item1.Value = "女";
            item1.Text = "女";
            list.Add(item1);

            return list;
        }

        public List<SelectListItem> GetCoursePass()
        {
            var list = new List<SelectListItem>();

            var item = new SelectListItem();
            item.Value = "0";
            item.Text = "未通过";
            list.Add(item);
            var item1 = new SelectListItem();
            item1.Value = "1";
            item1.Text = "通过未领取";
            list.Add(item1);
            var item2 = new SelectListItem();
            item2.Value = "2";
            item2.Text = "通过已领取";
            list.Add(item2);

            return list;
        }
	}
}
