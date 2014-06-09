using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hammer.Core.Models;

namespace Hammer.Core.Helpers
{
	public class ListHelper
	{
		public static IEnumerable<SelectListItem> GetBlogCategoryList()
		{
			using (SiteDataContext db = new SiteDataContext())
			{
				var list = from l in db.BlogCategories.AsEnumerable()
						   orderby l.CategoryName
						   select new SelectListItem { Value = l.CategoryID.ToString(), Text = l.CategoryName };

				return list.ToList();
			}
		}

		public static IEnumerable<SelectListItem> GetLanguageList()
		{
			var list = new List<SelectListItem>();
			var item = new SelectListItem { Text = "中文", Value = "zh" };
			list.Add(item);
			var item1 = new SelectListItem { Text = "英文", Value = "en" };
			list.Add(item1);

			return list.ToList();
		}

		//public static IEnumerable<Category> GetCategories(int parentID, string languageID)
		//{
		//    using (SiteDataContext db = new SiteDataContext())
		//    {
		//        return db.Categories.Where(m => m.ParentID == parentID && m.LanguageID == languageID).OrderBy(m => m.SortOrder).ToList();
		//    }
		//}

		//public static IEnumerable<SelectListItem> GetCategoryList()
		//{
		//    using (SiteDataContext db = new SiteDataContext())
		//    {
		//        var list = from l in db.Categories.AsEnumerable()
		//                   orderby l.CategoryName
		//                   select new SelectListItem { Value = l.CategoryID.ToString(), Text = l.CategoryName };

		//        return list.ToList();
		//    }
		//}

	}
}