using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using Hammer.Membership.Models;

namespace Hammer.Core.Models
{
	public class SiteDataContext : DbContext
	{
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<BlogComment> BlogComments { get; set; }
		public DbSet<BlogCategory> BlogCategories { get; set; }
		public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<Links> Links { get; set; }

        public DbSet<Student> Students { get; set; }

		//public DbSet<Cart> Carts { get; set; }
		//public DbSet<CartDetail> CartDetails { get; set; }
		//public DbSet<Order> Orders { get; set; }
		//public DbSet<OrderDetail> OrderDetails { get; set; }

		//public DbSet<Product> Products { get; set; }
		//public DbSet<ProductColor> ProductColors { get; set; }
		//public DbSet<ProductTune> ProductTunes { get; set; }
		//public DbSet<Category> Categories { get; set; }

		public DbSet<Gallery> Galleries { get; set; }
		public DbSet<GalleryDetail> GalleryDetails { get; set; }
		public DbSet<Video> Videos { get; set; }
		public DbSet<ApplyOnline> Applies { get; set; }

		public DbSet<User> Users{ get; set; }
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
			// blog categories

			var blogCategories = new List<BlogCategory>
			{
				new BlogCategory 
				{
					CategoryName="Programming",
					Slug="programming",
					Blogs= new List<Blog> 
					{
						new Blog {
							BlogTitle="10 top websites", AuthorID="nestors", DateCreated=DateTime.Now, Slug="10-top-websites", BlogContent="Websites are good, but how good you need? check at the following 10 awesome coding",
							BlogComments = new List<BlogComment>
							{
								new BlogComment { Name="Nestor", Email="nsulu@hotmail.com", Website="cloud1design.com", DateCreated=DateTime.Now, Message="Awesome, thanks for sharing"},
								new BlogComment { Name="Manuel", Email="nestorsulu@gmail.com", Website="cloud1design.com", DateCreated=DateTime.Now, Message="It helped a lot, thanks guys"},
								new BlogComment { Name="Maria", Email="maria@clou1design.com", Website="cloud1design.com", DateCreated=DateTime.Now, Message="Nice designs, but difficult for CSS"}
							},
							BlogTags = new List<BlogTag>
							{
								new BlogTag { Tag="mvc3"},
								new BlogTag { Tag="top-10"},
								new BlogTag { Tag="asp-net"}
							}
						},
						new Blog {BlogTitle="8 IE6 css fixes and hacks", AuthorID="nestors", DateCreated=DateTime.Now, Slug="8-ie6-css-fixes-and-hacks", BlogContent="Lets face it, IE6 is there and we need to deal with it, check at these common fixes and hacks"}
					}
				},
				new BlogCategory 
				{
					CategoryName="Design",
					Slug="design",
					Blogs= new List<Blog> 
					{
						new Blog {BlogTitle="Color theory", AuthorID="nestors", DateCreated=DateTime.Now, Slug="color-theory", BlogContent="When designing, what colors to uses? here are the basics for color theory"},
						new Blog {BlogTitle="10 top designs to check", AuthorID="nestors", DateCreated=DateTime.Now, Slug="10-top-designs-to-check", BlogContent="When design is needed, colors are not enough, creativity matters, look at these 10 pieces or art"}
					}
				},
				new BlogCategory { CategoryName = "SEO", Slug = "seo" },
				new BlogCategory { CategoryName = "Tutorials", Slug = "tutorials" },
				new BlogCategory { CategoryName = "China", Slug = "china" }
			};

			blogCategories.ForEach(bc => context.BlogCategories.Add(bc));
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