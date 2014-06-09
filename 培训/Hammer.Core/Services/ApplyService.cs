using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hammer.Core.Models;
using System.Data.Entity;

namespace Hammer.Core.Services
{
	public class ApplyService
	{
		SiteDataContext db = new SiteDataContext();

		public void InsertApply(ApplyOnline apply)
		{
			apply.DateCreated = DateTime.Now;
			db.Applies.Add(apply);
			Save();
		}

		public ApplyOnline GetApply(int ApplyID)
		{
			return db.Applies.Find(ApplyID);
		}

		public void UpdateApply(ApplyOnline apply)
		{
			var b = GetApply(apply.ApplyID);

			b.Gender = apply.Gender;
			b.Phone = apply.Phone;
			b.Name = apply.Name;
			b.Email = apply.Email;
			b.ApplyContent = apply.ApplyContent;
			b.QQ = apply.QQ;
			b.Course = apply.Course;
		}

		public IQueryable<ApplyOnline> GetApplies()
		{
			return db.Applies;
		}
		public void DeleteApply(int ApplyID)
		{
			var apply = GetApply(ApplyID);
			db.Applies.Remove(apply);
		}

		public void Save()
		{
			db.SaveChanges();
		}
	}
}