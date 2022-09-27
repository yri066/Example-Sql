using LinqToDB;
using LinqToDB.Data;
using ConsoleApp.Lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Lib.Linq2db
{
	/// <summary>
	/// Контекст подключения к базе для Linq2db.
	/// </summary>
	internal class DbConnection : DataConnection
	{
		/// <summary>
		/// Констркутор по умолчанию.
		/// </summary>
		public DbConnection() : base("DefaultConnection")
		{ }

		/// <summary>
		/// Автор.
		/// </summary>
		public ITable<Author> Author => this.GetTable<Author>();

		/// <summary>
		/// Книга.
		/// </summary>
		public ITable<Book> Book => this.GetTable<Book>();

		/// <summary>
		/// Издатель.
		/// </summary>
		public ITable<Publisher> Publisher => this.GetTable<Publisher>();

		/// <summary>
		/// Выдача.
		/// </summary>
		public ITable<Issue> Issue => this.GetTable<Issue>();

		/// <summary>
		/// Читатель.
		/// </summary>
		public ITable<Reader> Reader => this.GetTable<Reader>();
	}
}
