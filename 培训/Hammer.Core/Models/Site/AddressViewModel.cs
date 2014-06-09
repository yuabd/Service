using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Hammer.Core.Models.Site
{
	public class AddressViewModel
	{
		[MaxLength(10)]
		[Required]
		public string ShippingName { get; set; }
		[MaxLength(13)]
		[Required]
		public string Phone { get; set; }
		[Required]
		[MaxLength(10)]
		public string PostCode { get; set; }
		[Required]
		[MaxLength(50)]
		public string Email { get; set; }
		[Required]
		[MaxLength(100)]
		public string ShippingAddress1 { get; set; }
		[MaxLength(100)]
		public string ShippingAddress2 { get; set; } //option
		[MaxLength(20)]
		[Required]
		public string Province { get; set; }
		[Required]
		[MaxLength(20)]
		public string Country { get; set; }
	}
}
