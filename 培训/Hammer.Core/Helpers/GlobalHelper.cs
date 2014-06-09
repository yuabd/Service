using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Hammer.Core.Helpers
{
	public class GlobalHelper
	{
		public static string LanguageID
		{
			get
			{
				string languageID = "en";

				// save in cookie (maybe not needed, as always read from url)
				HttpCookie cookie = HttpContext.Current.Request.Cookies["selectedLanguage"];

				if (cookie != null)
				{
					languageID = cookie.Value;
				}

				return languageID;
			}
		}
	}
}
