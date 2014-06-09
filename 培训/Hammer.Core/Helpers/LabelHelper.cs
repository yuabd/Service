using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hammer.Core.Models;

namespace Hammer.Core.Helpers
{
	public class LabelHelper
	{
		public static string GetBlogCategoryName(int categoryID)
		{
			using (SiteDataContext db = new SiteDataContext())
			{
				return db.BlogCategories.SingleOrDefault(p => p.CategoryID == categoryID).CategoryName;
			}
		}


		public static string GetGalleryPhoto(int galleryID)
		{
			using (SiteDataContext db = new SiteDataContext())
			{
				var photo = from g in db.GalleryDetails.AsEnumerable()
							where g.GalleryID == galleryID
							orderby g.SortOrder
							select g.PictureFile;
				return photo.FirstOrDefault();
			}
		}


        public string GetCourseName(string courseID)
        {
            using (SiteDataContext db = new SiteDataContext())
            {
                if (string.IsNullOrEmpty(courseID) || courseID == "0")
                {
                    return "";
                }

                var id = ToInt(courseID);

                var course = db.Blogs.FirstOrDefault(m => m.BlogID == id);
                if (course == null)
                {
                    return "";
                }

                return course.BlogTitle;
            }
        }

        public int ToInt(string courseID)
        {
            var id = 0;
            try
            {
               id = Convert.ToInt32(courseID);
            }
            catch (Exception e)
            {
                id = 0;
            }
            return id;
        }

		public static string GetBlogCategoryName(string slug)
		{
			using (SiteDataContext db = new SiteDataContext())
			{
				return db.BlogCategories.SingleOrDefault(p => p.Slug == slug).CategoryName;
			}
		}

		//public static string GetCategoryName(int categoryID)
		//{
		//    using (SiteDataContext db = new SiteDataContext())
		//    {
		//        var category = db.Categories.Find(categoryID);
		//        return category != null ? category.CategoryName : "";
		//    }
		//}

		//public static int GetCategoryByProduct(int productID)
		//{
		//    using (SiteDataContext db = new SiteDataContext())
		//    {
		//        var product = db.Products.Find(productID);

		//        return product != null ? product.CategoryID : 0;
		//    }
		//}
	}
}