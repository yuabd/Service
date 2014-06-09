﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Hammer.Core;
using System.Data.Entity;

namespace ShaXuan
{
	// 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
	// 请访问 http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // 路由名称
				"{controller}/{action}/{id}", // 带有参数的 URL
				new { controller = "Company", action = "Index", id = UrlParameter.Optional }, // 参数默认值
				new[] { "ShaXuan.Controllers" }
			);

		}

		protected void Application_Start()
		{
			//ShaXuan.Models.DatabaseSetup.SetInitializer();

			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
			if (HttpContext.Current.User != null)
			{
				if (HttpContext.Current.User.Identity.IsAuthenticated)
				{
					if (HttpContext.Current.User.Identity is FormsIdentity)
					{
						FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
						FormsAuthenticationTicket ticket = id.Ticket;

						// Get the stored user-data, in this case, our roles
						string userData = ticket.UserData;
						string[] roles = userData.Split(',');
						HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(id, roles);
					}
				}
			}
		}
	}
}