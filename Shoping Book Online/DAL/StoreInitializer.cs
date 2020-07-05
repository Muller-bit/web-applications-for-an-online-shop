using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using FizzWare.NBuilder;
using OnlineShopBooks.Models;
using WebGrease.Css.Extensions;

namespace OnlineShopBooks.DAL
{
	public class StoreInitializer : DropCreateDatabaseAlways<StoreContext>
	{
		protected override void Seed(StoreContext context)
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
		}
	}
}
