using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hammer.Core.Models.Site
{
	public class ContactViewModel
	{
		[Required(ErrorMessage = "必填项")]
		public string ContactName { get; set; }

		[Required(ErrorMessage = "必填项")]
		[RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid")]
		public string Email { get; set; }

		[Required(ErrorMessage="必填项")]
		public string PhoneNo { get; set; }

		//[Required(ErrorMessage = "Required")]
		public string Message { get; set; }

		public string Country { get; set; }

		[Required(ErrorMessage = "必填项")]
		[RegularExpression("3", ErrorMessage = "Incorrect")]
		public string SumCheck { get; set; }
	}
}