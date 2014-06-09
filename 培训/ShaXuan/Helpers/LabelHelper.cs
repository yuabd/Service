using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hammer.Core.Models;

namespace ShaXuan.Helpers
{
    public class LabelHelper
    {
        public LabelHelper()
        {
        }

        public string GetBlogCategoryName(int categoryID)
        {
            using (SiteDataContext db = new SiteDataContext())
            {
                var category = db.BlogCategories.FirstOrDefault(p => p.CategoryID == categoryID);
                return category != null ? category.CategoryName : "";
            }
        }

        public Blog GetFirstBlog(int categoryID)
        {
            using (SiteDataContext db = new SiteDataContext())
            {
                return db.Blogs.Where(m => m.CategoryID == categoryID && m.IsPublic == true).OrderByDescending(m => m.SortOrder).ThenByDescending(m => m.DateCreated).FirstOrDefault();
            }
        }

        //public static string GetBlogCategoryName(string slug)
        //{
        //    using (SiteDataContext db = new SiteDataContext())
        //    {
        //        return db.BlogCategories.SingleOrDefault(p => p.Slug == slug).CategoryName;
        //    }
        //}
        /// <summary>
        /// 搜索学生
        /// </summary>
        /// <param name="name">学生姓名</param>
        /// <param name="studentID">准考证号</param>
        /// <returns></returns>
        public Student SearchStudent(string name, string studentID)
        {
            using (SiteDataContext db = new SiteDataContext())
            {
                var item = (from l in db.Students
                            where l.Name == name && l.StudentID == studentID
                            select l).FirstOrDefault();
                if (item != null)
                {
                    var courseID = Convert.ToInt32(item.Course);
                    var course = db.Blogs.FirstOrDefault(m => m.BlogID == courseID);
                    item.CourseName = course == null ? "" : course.BlogTitle;
                }

                return item;
            }
        }
    }
}