using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hammer.Core.Models;

namespace Hammer.Core.Services
{
    public class LinkService
    {
        private SiteDataContext db = new SiteDataContext();

        public void InsertLink(Links links)
        {
            try
            {
                links.DateCreated = DateTime.Now;
                db.Links.Add(links);
                db.SaveChanges();
            }
            catch (Exception e)
            {
            }
        }

        public Links GetLink(int id)
        {
            var link = (from l in db.Links
                        where l.ID == id
                        select l).FirstOrDefault();

            return link;
        }

        public void UpdateLink(Links link)
        {
            var l = db.Links.Find(link.ID);

            if (l == null)
            {
                return;
            }

            try
            {
                l.Contact = link.Contact;
                l.Description = link.Description;
                l.Email = link.Email;
                l.Name = link.Name;
                l.LinkUrl = link.LinkUrl;
                l.PictureFile = link.PictureFile;
                l.SortOrder = link.SortOrder;
                l.IsEnable = link.IsEnable;
                //l.DateCreated = DateTime.Now;

                db.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public void DeleteLink(int id)
        {
            var link = db.Links.Find(id);
            if (link == null)
            {
                return;
            }

            db.Links.Remove(link);
            db.SaveChanges();
        }

        public List<Links> GetLinks()
        {
            var list = (from l in db.Links
                        orderby l.SortOrder descending
                        select l).ToList();

            return list;
        }
    }
}
