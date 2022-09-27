using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Lib.Entities
{
	/// <summary>
	/// Книга.
	/// </summary>
	[Table(Name = "Book")]
	public class Book
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		[PrimaryKey, Identity]
		public int Id { get; set; }

		/// <summary>
		/// Название книги.
		/// </summary>
		[Column]
		public string Name;

		/// <summary>
		/// Идентификатор автора.
		/// </summary>
		[Column]
		public Guid AuthorId;

		/// <summary>
		/// Идентификатор издателя.
		/// </summary>
		[Column]
		public Guid PublisherId;

		/// <summary>
		/// Год издания.
		/// </summary>
		[Column]
		public int PublicationYear;
	}
}
