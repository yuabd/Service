using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Hammer.Membership.Models;

namespace Hammer.Membership.Helpers
{
	public class ListHelper
	{
		public static IEnumerable<SelectListItem> GetRoleList()
		{
			using (SiteDataContext db = new SiteDataContext())
			{
				var list = from l in db.UserRoles.AsEnumerable()
						   orderby l.RoleID
						   select new SelectListItem { Value = l.RoleID.ToString(), Text = l.RoleID };

				return list.ToList();
			}
		}
	}
}
