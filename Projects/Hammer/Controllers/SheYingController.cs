using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyUI.Controllers
{
    public class SheYingController : Controller
    {
        //
        // GET: /SheYing/

        public ActionResult Index()
        {
            ViewBag.About = "active";
            var doc = new Helpers.SystemHelper().GetDocumentByID(1);

            return View(doc);
        }

    }
}
