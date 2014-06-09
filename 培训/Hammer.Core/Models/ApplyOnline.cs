using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hammer.Core.Models
{
	public class ApplyOnline
	{
		[Key]
		public int ApplyID { get; set; }
		[Required(ErrorMessage = "必填")]
		[MaxLength(30)]
		public string Name { get; set; }
		[MaxLength(15)]
		public string Gender { get; set; }
		[Required(ErrorMessage = "必填")]
		[MaxLength(11, ErrorMessage="你输入的号码过长")]
		public string Phone { get; set; }
		public string QQ { get; set; }
		public string Email { get; set; }
		[Required(ErrorMessage = "必填")]
		public string Course { get; set; }//想报的课程名称
		[MaxLength(1000)]
		public string ApplyContent { get; set; }
		public DateTime DateCreated { get; set; }

		[NotMapped]
		public string Check { get; set; }
        [NotMapped]
        public string CourseName { get { return new Helpers.LabelHelper().GetCourseName(Course); } }
	}
}