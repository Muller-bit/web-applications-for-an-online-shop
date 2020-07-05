using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShopBooks.Models;

namespace OnlineShopBooks.DAL
{
	public class StoreContext : IdentityDbContext<ApplicationUser>
	{
		public StoreContext() : base("ConnectionString")
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoreContext, OnlineShopBooks.Migrations.Configuration>());
		}

		public DbSet<Book> Books { get; set; }
		public DbSet<AudioBook> AudioBooks { get; set; }

		public static StoreContext Create()
		{
			return new StoreContext();
		}

	}
}
