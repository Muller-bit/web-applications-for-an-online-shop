using System.Collections.Generic;
using FizzWare.NBuilder;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShopBooks.Models;

namespace OnlineShopBooks.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<OnlineShopBooks.DAL.StoreContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}

		protected override void Seed(OnlineShopBooks.DAL.StoreContext context)
		{
			var books = Builder<Book>.CreateListOfSize(100)
				.All()
				.With(b => b.Title = string.Join(" ", Faker.Lorem.Words(2)))
				.With(b => b.Author = Faker.Name.FullName())
				.With(b => b.Description = string.Join(" ", Faker.Lorem.Sentences(2)))
				.With(b => b.Pages = Faker.RandomNumber.Next(50, 1000))
				.With(b => b.Price = Faker.RandomNumber.Next(10, 100))
				.With(b => b.Count = Faker.RandomNumber.Next(0, 15))
				.Build();

			var audioBooks = Builder<AudioBook>.CreateListOfSize(70)
				.All()
				.With(b => b.Title = string.Join(" ", Faker.Lorem.Words(2)))
				.With(b => b.Author = Faker.Name.FullName())
				.With(b => b.Description = string.Join(" ", Faker.Lorem.Sentences(2)))
				.With(b => b.Format = "MP3")
				.With(b => b.Length = Faker.RandomNumber.Next(20, 500))
				.With(b => b.Size = Faker.RandomNumber.Next(0, 50))
				.With(b => b.Price = Faker.RandomNumber.Next(10, 100))
				.With(b => b.Count = Faker.RandomNumber.Next(0, 15))
				.Build();

			context.Books.AddOrUpdate(c => c.Id, books.ToArray());
			context.AudioBooks.AddOrUpdate(c => c.Id, audioBooks.ToArray());

			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
			if (!roleManager.RoleExists("Customer")) roleManager.Create(new IdentityRole("Customer"));
			if (!roleManager.RoleExists("Admin")) roleManager.Create(new IdentityRole("Admin"));

			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

			//Admins
			var admins = new List<ApplicationUser>
			{
				new ApplicationUser{ UserName = "dnldcode@gmail.com", Email = "dnldcode@gmail.com" },
			};
			string defaultPassword = "pass123";
			foreach (var admin in admins)
			{
				if (userManager.FindByName(admin.UserName) == null)
				{
					userManager.Create(admin, defaultPassword);
					userManager.AddToRole(admin.Id, "Admin");
				}
			}

			//Customers
			var customers = new List<ApplicationUser>
			{
				new ApplicationUser{ UserName = "arslanbek.t@gmail.com", Email = "arslanbek.t@gmail.com" }
			};
			foreach (var c in customers)
			{
				if (userManager.FindByName(c.UserName) == null)
				{
					userManager.Create(c, defaultPassword);
					userManager.AddToRole(c.Id, "Customer");
				}
			}
		}
	}
}
