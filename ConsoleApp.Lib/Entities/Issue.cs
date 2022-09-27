using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Lib.Entities
{
	/// <summary>
	/// Выдача.
	/// </summary>
	[Table(Name = "Issue")]
	public class Issue
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		[PrimaryKey, Identity]
		public int Id { get; set; }

		/// <summary>
		/// Идентификатор книги.
		/// </summary>
		[Column]
		public int BookId;

		/// <summary>
		/// Идентификатор читателя.
		/// </summary>
		[Column]
		public int ReaderId;

		/// <summary>
		/// Дата выдачи.
		/// </summary>
		[Column]
		public DateTime IssueDate;

		/// <summary>
		/// Дата возврата.
		/// </summary>
		[Column]
		public DateTime ReturnDate;

		/// <summary>
		/// true - книга возвращена, false - книгу у читателя.
		/// </summary>
		[Column]
		public bool Returned;
	}
}
