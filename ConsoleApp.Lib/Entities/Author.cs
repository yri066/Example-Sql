using System;
using LinqToDB.Mapping;

namespace ConsoleApp.Lib.Entities
{
	/// <summary>
	/// Автор.
	/// </summary>
	[Table(Name = "Author")]
	public class Author
	{
		/// <summary>
		/// Идентификатор автора.
		/// </summary>
		[PrimaryKey, Identity]
		public Guid Id { get; set; }

		/// <summary>
		/// Имя автора.
		/// </summary>
		[Column]
		public string FirstName;

		/// <summary>
		/// Фамилия автора.
		/// </summary>
		[Column]
		public string LastName;

		/// <summary>
		/// Отчество автора.
		/// </summary>
		[Column]
		public string Patronymic;

		/// <summary>
		/// Сгенерировать строковое представление объекта.
		/// </summary>
		/// <returns>Строковое представление объекта.</returns>
		public override string ToString()
		{
			return $"Id \"{Id}\" Имя \"{FirstName}\" Фамилия \"{LastName}\" " +
					$"Отчество \"{Patronymic}\"";
		}
	}
}
