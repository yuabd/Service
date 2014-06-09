﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Hammer.Common
{
	public class EmailAttribute: RegularExpressionAttribute
	{
		public EmailAttribute()
			: base("^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$") { }
	}
}
