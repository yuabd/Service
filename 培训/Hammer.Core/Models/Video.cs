using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hammer.Core.Models
{
	public class Video
	{
		public int VideoID { get; set; }
		[Required(ErrorMessage = "Required")]
		[MaxLength(60, ErrorMessage = "too large")]
		public string VideoName { get; set; }
		[MaxLength(300, ErrorMessage = "too large")]
		public string VideoDescription { get; set; }
		[MaxLength(2000, ErrorMessage = "too large")]
		[Required(ErrorMessage = "Required")]
		public string VideoCode { get; set; }
		[Required(ErrorMessage = "Required")]
		public DateTime DateTaken { get; set; }
		public bool IsPublic { get; set; }

		public string PictureFile { get; set; }

		// SEO
		[MaxLength(70, ErrorMessage = "too large")]
		public string PageTitle { get; set; }
		[MaxLength(150, ErrorMessage = "too large")]
		public string MetaDescription { get; set; }
		[MaxLength(100, ErrorMessage = "too large")]
		public string MetaKeywords { get; set; }
		[MaxLength(60, ErrorMessage = "too large")]
		public string Slug { get; set; }

		[NotMapped]
		public string PictureFolder { get { return "/Content/Videos"; } }
	}
}
