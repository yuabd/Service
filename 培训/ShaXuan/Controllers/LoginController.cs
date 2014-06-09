using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hammer.Core.Services;
using Hammer.Core.Models;
using System.Web.Security;
using Hammer.Membership.Services;
using Hammer.Core.Models.Site;


namespace ShaXuan.Controllers
{
    public class LoginController : Controller
    {
		private MembershipService membershipService = new MembershipService();
        //
        // GET: /Login/

		public ActionResult Index()
        {
            return View();
        }

		public ActionResult Login(string returnUrl)
		{
			LoginViewModel model = new LoginViewModel();

			return View(model);
		}

		[HttpPost]
		public ActionResult Login(LoginViewModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				var loginMessage = membershipService.Login(model.UserID, model.Password, model.RememberMe);

				if (loginMessage == "OK")
				{
					if (returnUrl != null)
						return Redirect(returnUrl.ToString());
					else
                        return RedirectToAction("Index", "Apply", new { areas = "admin" });
				}
				else
				{
					ViewBag.LoginError = loginMessage;
					return View(model);
				}
			}
			else
			{
				return View(model);
			}
		}

		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();
			Session.Abandon();

			return Redirect("/");
		}

    }
}
