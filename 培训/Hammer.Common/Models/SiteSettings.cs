using System;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Web;
using System.Linq;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace Hammer.Common.Models
{
	public class SiteSettings : ConfigurationSection
	{
		[StringLength(30),Required]
		public string CompanyName { get; set; }
		[StringLength(50),Required]
		public string CompanyNameFull  { get; set; }
		[StringLength(50),Required]
		public string CompanyWebsite  { get; set; }
		[Email]
		[StringLength(60),Required]
		public string CompanyEmail  { get; set; }
		[Email]
		[StringLength(60),Required]
		public string CompanyEmailAuto  { get; set; }
		[StringLength(30),Required]
		public string CompanyPhoneNo  { get; set; }
        [StringLength(500)]
        public string Notice { get; set; }

		public SiteSettings()
		{
			var xml = XDocument.Load(HttpContext.Current.Server.MapPath("~/SiteSettings.xml"));
			XAttribute field;

			field = (from m in xml.Descendants("companyName") select m.Attribute("value")).SingleOrDefault();
			CompanyName = field.Value;
			field = (from m in xml.Descendants("companyNameFull") select m.Attribute("value")).SingleOrDefault();
			CompanyNameFull = field.Value;
			field = (from m in xml.Descendants("companyWebsite") select m.Attribute("value")).SingleOrDefault();
			CompanyWebsite = field.Value;
			field = (from m in xml.Descendants("companyEmail") select m.Attribute("value")).SingleOrDefault();
			CompanyEmail = field.Value;
			field = (from m in xml.Descendants("companyEmailAuto") select m.Attribute("value")).SingleOrDefault();
			CompanyEmailAuto = field.Value;
			field = (from m in xml.Descendants("companyPhoneNo") select m.Attribute("value")).SingleOrDefault();
			CompanyPhoneNo = field.Value;
            field = (from m in xml.Descendants("Notice") select m.Attribute("value")).SingleOrDefault();
            Notice = field.Value;
		}

	}
}