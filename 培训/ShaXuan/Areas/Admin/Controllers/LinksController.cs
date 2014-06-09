using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hammer.Core.Services;
using Hammer.Common.Models;
using Hammer.Core.Models;

namespace ShaXuan.Areas.Admin.Controllers
{
    public class LinksController : Controller
    {
        private LinkService ls = new LinkService();
        //
        // GET: /Admin/Links/

        public ActionResult Index(int? page)
        {
            var links = ls.GetLinks();
            var model = new Paginated<Links>(links, page ?? 1, 20);

            return View(model);
        }

        public ActionResult Add()
        {
            var link = new Links();
            link.SortOrder = 0;

            return View(link);
        }

        [HttpPost]
        public ActionResult Add(Links links)
        {
            if (ModelState.IsValid)
            {
                ls.InsertLink(links);

                return RedirectToAction("Index");
            }

            return View(links);
        }

        public ActionResult Edit(int id)
        {
            var link = ls.GetLink(id);

            return View(link);
        }

        [HttpPost]
        public ActionResult Edit(Links links)
        {
            if (ModelState.IsValid)
            {
                ls.UpdateLink(links);
                
                return RedirectToAction("Index");
            }

            return View(links);
        }

        public ActionResult Delete(int id)
        {
            ls.DeleteLink(id);
            
            return RedirectToAction("Index");
        }

    }
}
