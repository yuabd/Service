using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hammer.Core.Helpers;
using Hammer.Core.Services;
using Hammer.Core.Models;
using Hammer.Common.Models;

namespace Hammer.Core.Models.Site
{
	public class BlogsViewModel
	{
		public Paginated<Blog> Blogs { get; private set; }

		public IEnumerable<BlogCategory> Categories { get; private set; }

		public IEnumerable<String> PopularTags { get; private set; }

		public IEnumerable<Archive> Archives { get; private set; }

		public BlogsViewModel(
			Paginated<Blog> blogs,
			IEnumerable<BlogCategory> categories,
			IEnumerable<String> popularTags,
			IEnumerable<Archive> archives
			)
		{
			Blogs = blogs;
			Categories = categories;
			PopularTags = popularTags;
			Archives = archives;
		}
	}
}