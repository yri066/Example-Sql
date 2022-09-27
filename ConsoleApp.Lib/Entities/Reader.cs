using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Lib.Entities
{
	/// <summary>
	/// Читатель.
	/// </summary>
	[Table(Name = "Reader")]
	public class Reader
	{

		/// <summary>
		/// Идентификатор.
		/// </summary>
		[PrimaryKey, Identity]
		public int Id { get; set; }

		/// <summary>
		/// Имя.
		/// </summary>
		[Column]
		public string FirstName;

		/// <summary>
		/// Фамилия.
		/// </summary>
		[Column]
		public string LastName;

		/// <summary>
		/// Отчество.
		/// </summary>
		[Column]
		public string Patronymic;

		/// <summary>
		/// Адрес.
		/// </summary>
		[Column]
		public string Address;

		/// <summary>
		/// Телефон.
		/// </summary>
		[Column]
		public string Phone;

		/// <summary>
		/// Сгенерировать строковое представление объекта.
		/// </summary>
		/// <returns>Строковое представление объекта.</returns>
		public override string ToString()
		{
			return $"Имя \"{FirstName}\" Фамилия \"{LastName}\" " +
					$"Отчество \"{Patronymic}\" " +
					$"Отчество \"{Patronymic}\" Адрес \"{Address}\" ";
		}
	}
}
