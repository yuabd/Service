using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hammer.Core.Services;

namespace Hammer.Core.Models.Site
{
	public class BlogViewModel
	{
		public Blog Blog { get; private set; }

		public BlogComment BlogComment { get; private set; }

		public IEnumerable<BlogCategory> Categories { get; private set; }

		public IEnumerable<String> PopularTags { get; private set; }

		public IEnumerable<Archive> Archives { get; private set; }

		public BlogViewModel(
			Blog blog, 
			BlogComment blogComment,
			IEnumerable<BlogCategory> categories,
			IEnumerable<String> popularTags,
			IEnumerable<Archive> archives)
		{
			Blog = blog;
			BlogComment = blogComment;
			Categories = categories;
			PopularTags = popularTags;
			Archives = archives;
		}
	}
}