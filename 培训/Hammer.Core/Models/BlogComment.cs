using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Hammer.Common;

namespace Hammer.Core.Models
{
	public class BlogComment
	{
		[Key]
		public int CommentID { get; set; }
		public int BlogID { get; set; }
		[MaxLength(30)]
		[Required]
		public string Name { get; set; }
		[MaxLength(60)]
		[Required]
		[Email]
		public string Email { get; set; }
		[MaxLength(100)]
		public string Website { get; set; }
		[Required]
		[MaxLength(1000)]
		public string Message { get; set; }
		public bool IsPublic { get; set; }
		public DateTime DateCreated { get; set; }

		public virtual Blog Blog { get; set; }

		[NotMapped]
		public string GravatarHash { get { return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Email.Trim().ToLower(), "MD5").ToLower(); } }
	}
}