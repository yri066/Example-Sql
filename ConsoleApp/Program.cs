using System;
using System.Configuration;
using LinqToDB.Mapping;
using ConsoleApp.Lib.AdoNet;
using ConsoleApp.Lib.Entities;
using ConsoleApp.Lib.Interfaces;
using ConsoleApp.Lib.Linq2db;

namespace ConsoleApp
{
	internal class Program
	{
		/// <summary>
		/// Способ подключения
		/// </summary>
		private const string adoNet = "ADO.NET";

		/// <summary>
		/// Способ подключения
		/// </summary>
		private const string linq2db = "Linq2db";

		static void Main(string[] args)
		{
			string connectionFileString = string.Format(ConfigurationManager.ConnectionStrings["FileConnection"].ConnectionString, Environment.CurrentDirectory);

			RegisterLinq2dbBuilder();

			RunAdoNet(connectionFileString);
			RunLinq2db();
		}

		/// <summary>
		/// Демонстрация работы Ado.Net.
		/// </summary>
		/// <param name="connectionString">Строка подключения.</param>
		private static void RunAdoNet(string connectionString)
		{
			var adoNetDataProvider = new AdoNetDataProvider(connectionString);
			var author = new Author()
			{
				FirstName = "Александр",
				LastName = "Пушкин",
				Patronymic = "Сергеевич"
			};

			GetAuthorBooks(adoNet, adoNetDataProvider);
			GetIssueReaderViewModel(adoNet, adoNetDataProvider);
			FindAuthor(adoNet, adoNetDataProvider);
			AddAuthor(adoNet, adoNetDataProvider, author);
		}

		/// <summary>
		/// Демонстрация работы Linq2db.
		/// </summary>
		private static void RunLinq2db()
		{
			var linq2dbDataProvider = new Linq2dbDataProvider();
			var author = new Author()
			{
				FirstName = "Лев",
				LastName = "Толстой",
				Patronymic = "Николаевич"
			};

			GetAuthorBooks(linq2db, linq2dbDataProvider);
			GetIssueReaderViewModel(linq2db, linq2dbDataProvider);
			FindAuthor(linq2db, linq2dbDataProvider);
			AddAuthor(linq2db, linq2dbDataProvider, author);
		}


		/// <summary>
		/// Список авторов и их изданные книги.
		/// </summary>
		private static void GetAuthorBooks(string tool, ISqlQuery provider)
		{
			Console.WriteLine(tool);
			Console.WriteLine("Список авторов и их изданные книги:\n");
			var authorBooks = provider.GetAuthorBooks();

			if (authorBooks == null)
			{
				throw new ArgumentException(nameof(authorBooks));
			}

			foreach (var author in authorBooks)
			{
				Console.WriteLine(author.ToString());
			}

			Console.ReadLine();
			Console.Clear();
		}

		/// <summary>
		/// Список людей, не вернувших книги вовремя.
		/// </summary>
		private static void GetIssueReaderViewModel(string tool, ISqlQuery provider)
		{
			var readers = provider.GetReaderNotReturnedBook();

			if (readers == null)
			{
				throw new ArgumentException(nameof(readers));
			}

			Console.WriteLine(tool);
			Console.WriteLine("Список пользователей, просрочивших сдачу книги:\n");

			foreach (var reader in readers)
			{
				Console.WriteLine(reader.ToString());
			}

			Console.ReadLine();
			Console.Clear();
		}

		/// <summary>
		/// Поиск автора по id.
		/// </summary>
		private static void FindAuthor(string tool, ISqlQuery provider)
		{
			var author = provider.GetAuthor(new Guid("EEC2451A-469C-42D2-8243-5DD6C5F36EBD"));
			Console.WriteLine(tool);
			Console.WriteLine("Найти автора по Id: EEC2451A-469C-42D2-8243-5DD6C5F36EBD\n");

			if (author == null)
			{
				throw new ArgumentException(nameof(author));
			}

			Console.WriteLine(author.ToString());

			Console.ReadLine();
			Console.Clear();
		}

		/// <summary>
		/// Добавление нового автора.
		/// </summary>
		private static void AddAuthor(string tool, ISqlQuery provider, Author author)
		{
			Console.WriteLine(tool);
			ShowAllAuthor(provider);

			Console.WriteLine($"Добавление нового автора: {author.FirstName} {author.LastName} {author.Patronymic}");


			provider.AddAuthor(author);
			ShowAllAuthor(provider);

			Console.Clear();
		}

		/// <summary>
		/// Вывести список всех авторов.
		/// </summary>
		private static void ShowAllAuthor(ISqlQuery provider)
		{
			Console.WriteLine("\nСписок всех авторов\n");

			var authors = provider.GetAllAuthor();

			foreach (var authorInfo in authors)
			{
				Console.WriteLine(authorInfo.ToString());
			}

			Console.ReadLine();
		}

		/// <summary>
		/// Регистрация служебного билдера для Linq2db
		/// </summary>
		private static void RegisterLinq2dbBuilder()
		{
			var builder = new MappingSchema().GetFluentMappingBuilder();

			builder.Entity<Author>()
				.HasTableName("Author")
				.HasSchemaName("dbo")
				.HasIdentity(x => x.Id)
				.HasPrimaryKey(x => x.Id);

			builder.Entity<Book>()
				.HasTableName("Book")
				.HasSchemaName("dbo")
				.HasIdentity(x => x.Id)
				.HasPrimaryKey(x => x.Id);

			builder.Entity<Publisher>()
				.HasTableName("Publisher")
				.HasSchemaName("dbo")
				.HasIdentity(x => x.Id)
				.HasPrimaryKey(x => x.Id);

			builder.Entity<Issue>()
				.HasTableName("Issue")
				.HasSchemaName("dbo")
				.HasIdentity(x => x.Id)
				.HasPrimaryKey(x => x.Id);

			builder.Entity<Reader>()
				.HasTableName("Reader")
				.HasSchemaName("dbo")
				.HasIdentity(x => x.Id)
				.HasPrimaryKey(x => x.Id);
		}
	}
}
