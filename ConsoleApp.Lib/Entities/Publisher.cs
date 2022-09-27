using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Lib.Entities
{
	/// <summary>
	/// Издатель.
	/// </summary>
	[Table(Name = "Publisher")]
	public class Publisher
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		[PrimaryKey, Identity]
		public Guid Id { get; set; }

		/// <summary>
		/// Название издательства.
		/// </summary>
		[Column]
		public string Name;
	}
}
