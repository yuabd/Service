using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hammer.Core.Services;
using System.Data.Entity;
using Hammer.Core.Models;

namespace Nail.Controllers
{
    public class ApplyOnlineController : Controller
    {
        //
        // GET: /ApplyOnline/
		ApplyService applyService = new ApplyService();
		//public ActionResult Index()
		//{
		//    var apply = new ApplyOnline();
		//    return View(apply);
		//}

		public ActionResult AddApply()
		{
			var apply = new ApplyOnline();
			ViewBag.Contact = "current";

			return View(apply);
		}

		[HttpPost]
		public ActionResult AddApply(ApplyOnline applyOnline)
		{
			applyOnline.DateCreated = DateTime.Now;
            if (applyOnline.Check != Session["ValidateCode"].ToString())
            {
                ViewBag.Error = "验证码错误";

                return View();
            }
			if (ModelState.IsValid)
			{
				applyService.InsertApply(applyOnline);
				applyService.Save();

				ViewBag.ThankYou = true;
				return View();
			}
			else
			{
				return View(applyOnline);
			}
		}

		//public ActionResult UpdateApply(int id)
		//{
		//    var applyOnline = applyService.GetApply(id);
		//    return View(applyOnline);
		//}

		//[HttpPost]
		//[ValidateInput(false)]
		//public ActionResult UpdateApply(ApplyOnline applyOnline)
		//{
		//    if (ModelState.IsValid)
		//    {
		//        applyService.UpdateApply(applyOnline);
		//        applyService.Save();
		//        return RedirectToAction("Index");
		//    }
		//    else
		//    {
		//        return View(applyOnline);
		//    }
		//}

    }
}
