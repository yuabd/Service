using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hammer.Core.Models.Site
{
	public class ContentViewModel
	{
		public Blog Content { get; private set; }
		public IEnumerable<Blog> Sidebar { get; private set; }

		public ContentViewModel(Blog content, IEnumerable<Blog> sidebar)
		{
			Content = content;
			Sidebar = sidebar;
		}
	}
}