using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hammer.Core.Services;
using Hammer.Core.Models;
using Hammer.Common.Models;

namespace ShaXuan.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
    public class ApplyController : Controller
    {
        //
        // GET: /Admin/Apply/
		ApplyService applyService = new ApplyService();
		public ActionResult Index(int? page, int? id)
		{
			var applies = applyService.GetApplies().OrderByDescending(m =>m.DateCreated).ToList();
			var papplies = new Paginated<ApplyOnline>(applies, page ?? 1, 25);

			return View(papplies);
		}

		public ActionResult DeleteApply(int id)
		{
			var apply = applyService.GetApply(id);
			applyService.DeleteApply(id);
			applyService.Save();
			return RedirectToAction("Index");
		}

    }
}
