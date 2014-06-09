using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.IO;

namespace ShaXuan.Helpers
{
	public class Utilities
	{
		public static string Substring(string source, int length)
		{
			if (source.Length > length)
			{
				return source.Substring(0, length - 3) + "...";
			}
			else
			{
				return source;
			}
		}

		public static string GenerateSlug(string phrase, int maxLength)
		{
			string str = phrase.ToLower();

			// invalid chars, make into spaces
			str = Regex.Replace(str, @"[^a-z0-9\s-]", "");		//for English language
			// convert multiple spaces/hyphens into one space  
			str = Regex.Replace(str, @"[\s-]+", " ").Trim();
			// cut and trim it
			str = str.Substring(0, str.Length <= maxLength ? str.Length : maxLength).Trim();
			// hyphens
			str = Regex.Replace(str, @"\s", "-");

			return str;
		}

        public static string GetFirstParagraph(string file, int? length = 200)
        {
            if (string.IsNullOrEmpty(file))
            {
                return "";
            }

            string[] Regexs =
                                {
                                    @"<script[^>]*?>.*?</script>",
                                    @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>",
                                    @"([\r\n])[\s]+",
                                    @"&(quot|#34);",
                                    @"&(amp|#38);",
                                    @"&(lt|#60);",
                                    @"&(gt|#62);",
                                    @"&(nbsp|#160);",
                                    @"&(iexcl|#161);",
                                    @"&(cent|#162);",
                                    @"&(pound|#163);",
                                    @"&(copy|#169);",
                                    @"&#(\d+);",
                                    @"-->",
                                    @"<!--.*\n"
                                };

            string[] Replaces =
                                {
                                    "",
                                    "",
                                    "",
                                    "\"",
                                    "&",
                                    "<",
                                    ">",
                                    " ",
                                    "\xa1", //chr(161),
                                    "\xa2", //chr(162),
                                    "\xa3", //chr(163),
                                    "\xa9", //chr(169),
                                    "",
                                    "\r\n",
                                    ""
                                };

            string s = file;
            for (int i = 0; i < Regexs.Length; i++)
            {
                s = new Regex(Regexs[i], RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(s, Replaces[i]);
            }
            s.Replace("<", "");
            s.Replace(">", "");
            s.Replace("\r\n", "");

            if (s.Length >= length)
            {
                return s.Substring(0, (int)length) + "...";
            }
            else
            {
                return s;
            }
        }

		public static string RenderViewToString(ControllerContext context, ViewDataDictionary viewData, TempDataDictionary tempData, string viewName, object model)
		{
			if (string.IsNullOrEmpty(viewName))
				viewName = context.RouteData.GetRequiredString("action");

			viewData.Model = model;

			using (StringWriter sw = new StringWriter())
			{
				ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(context, viewName);
				ViewContext viewContext = new ViewContext(context, viewResult.View, viewData, tempData, sw);
				viewResult.View.Render(viewContext, sw);

				return sw.GetStringBuilder().ToString();
			}
		}

		public static string RenderViewToString(ControllerContext context, string viewName, object model)
		{
			if (string.IsNullOrEmpty(viewName))
				viewName = context.RouteData.GetRequiredString("action");

			ViewDataDictionary viewData = new ViewDataDictionary(model);

			using (StringWriter sw = new StringWriter())
			{
				ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(context, viewName);
				ViewContext viewContext = new ViewContext(context, viewResult.View, viewData, new TempDataDictionary(), sw);
				viewResult.View.Render(viewContext, sw);

				return sw.GetStringBuilder().ToString();
			}
		}
	}
}
