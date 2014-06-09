﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hammer.Common.Models
{
	public class Paginated<T> : List<T>
	{
		// Required
		public int PageIndex { get; private set; }
		public int TotalRecords { get; private set; }
		public int TotalPages { get; private set; }
		public int PageSize { get; private set; }

		// Optional
		public int PageRange { get; set; }
		public bool PreviousNext { get; set; }
		public bool Continued { get; set; }
		public bool Advanced { get; set; }

		// Private
		private MvcHtmlString _pageList;

		public Paginated(IEnumerable<T> source, int pageIndex, int pageSize)
		{
			PageIndex = pageIndex;
			TotalRecords = source.Count();
			PageSize = pageSize;

			TotalPages = (int)Math.Ceiling(TotalRecords / (double)PageSize);
			PageRange = 10;

			PreviousNext = true;
			Continued = true;
			Advanced = true;

			this.AddRange(source.Skip((PageIndex - 1) * PageSize).Take(PageSize));
		}

		public MvcHtmlString Pager()
		{
			return _pageList;
		}

		public MvcHtmlString Pager(string pagerID)
		{
			string pageParamName = GetPageParameterName(pagerID);
			string pageParameter = "?" + pageParamName + "={0}";

			int currentPage = 1;

			if (HttpContext.Current.Request[pageParamName] != null)
				currentPage = Convert.ToInt32(HttpContext.Current.Request[pageParamName].ToString());

			// calculate limits and parameters
			int prevLimit = 1;
			int nextLimit = prevLimit + PageRange - 1;

			// look for right range to display
			while (currentPage > nextLimit)
			{
				prevLimit += PageRange;
				nextLimit = prevLimit + PageRange - 1;
			}

			// adjust nextLimit in case not exact multiple
			if (nextLimit > TotalPages) nextLimit = TotalPages;

			// generate pages list
			string pagesList = "";
			string urlParameters = GetUrlParameterList(pageParamName); // get the rest of the querystring parameters

			pagesList += "<ul class=\"pager\">";
			for (int i = prevLimit; i <= nextLimit; i++)
			{
				if (i != currentPage)
					pagesList += string.Format("<li><a href=\"" + pageParameter + "{1}\">{0}</a></li>", i, urlParameters);
				else
					pagesList += string.Format("<li class=\"current\">{0}</li>", i);
			}
			pagesList += "</ul>";

			// set prev/next ...
			if (Continued)
			{
				if (prevLimit - PageRange > 0)
					pagesList = string.Format("<span class=\"continued\"><a href=\"" + pageParameter + "{2}\">...</a></span> {1}",
						prevLimit - PageRange, pagesList, urlParameters);

				if (prevLimit + PageRange <= TotalPages)
					pagesList = string.Format("{1} <span class=\"continued\"><a href=\"" + pageParameter + "{2}\">...</a></span>",
						prevLimit + PageRange, pagesList, urlParameters);
			}

			// set prev/next page
			if (PreviousNext)
			{
				if (currentPage > 1)
					pagesList = string.Format("<span class=\"previous-next\"><a href=\"" + pageParameter + "{2}\">上一页</a></span> {1}",
						currentPage - 1, pagesList, urlParameters);

				if (currentPage + 1 <= TotalPages)
					pagesList = string.Format("{1} <span class=\"previous-next\"><a href=\"" + pageParameter + "{2}\">下一页</a></span>",
						currentPage + 1, pagesList, urlParameters);
			}

			// advanced
			if (Advanced)
				pagesList = string.Format("{0}<span> | 总： {1} | 页面数： {2} / {3}</span>", pagesList, TotalRecords, currentPage, TotalPages);

			pagesList = string.Format("<div class=\"pager-area\">{0}</div>", pagesList);

			_pageList = MvcHtmlString.Create(pagesList);

			return _pageList;
		}

		private string GetPageParameterName(string pagerID)
		{
			// if pageID is not the default means several pagers in one page then change param Page to ID_Page
			string pageParamName = "Page";

			if (pagerID.ToLower() != "pager")
				pageParamName = pagerID.ToString() + "_page";

			return pageParamName;
		}

		private string GetUrlParameterList(string pageParameterName)
		{
			var request = HttpContext.Current.Request;
			var parameters = new Dictionary<string, object>();
			request.QueryString.CopyTo(parameters);

			string parameterList = "";
			foreach (KeyValuePair<string, object> item in parameters)
			{
				if (item.Key != pageParameterName)
				{
					parameterList += string.Format("&{0}={1}", item.Key, item.Value);
				}
			}

			if (parameterList != "")
				parameterList = "&amp;" + parameterList.Substring(1);

			return parameterList;
		}
	}
}
