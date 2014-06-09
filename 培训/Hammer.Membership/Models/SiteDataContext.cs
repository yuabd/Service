using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Hammer.Membership.Models
{
	public class SiteDataContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<UserRoleJoin> UserRoleJoins { get; set; }

		// Twist our database
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			base.OnModelCreating(modelBuilder);
		}
	}

	public class SiteDataContextInitializer : DropCreateDatabaseAlways<SiteDataContext>
	{
		protected override void Seed(SiteDataContext context)
		{
			// users

			var user = new User { UserID = "admin", Password = "DAC177D41FD48F8627BD10D2689E8544", DateCreated = DateTime.Now, DateLastLogin = DateTime.Now };

			context.Users.Add(user);

			var roles = new List<UserRole>
			{
				new UserRole { RoleID = "Administrator" },
				new UserRole { RoleID = "Editor" },
				new UserRole { RoleID = "Customer" },
				new UserRole { RoleID = "Guest" }
			};

			roles.ForEach(m => context.UserRoles.Add(m));

			var userRoleJoin = new UserRoleJoin { UserID = "admin", RoleID = "Administrator" };

			context.UserRoleJoins.Add(userRoleJoin);
		}
	}

	/// <summary>
	/// Simulates the Code First Initializer to fill with sample data the new database if recreated
	/// </summary>
	//public class DatabaseSetup
	//{
	//    public static void SetInitializer()
	//    {
	//        Database.SetInitializer<SiteDataContext>(new SiteDataContextInitializer());
	//    }
	//}
}
