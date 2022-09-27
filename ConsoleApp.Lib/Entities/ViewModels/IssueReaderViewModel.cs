using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Lib.Entities.ViewModels
{
	/// <summary>
	/// Информация о пользователе не вернувший книгу вовремя
	/// </summary>
	public class IssueReaderViewModel
	{
		/// <summary>
		/// Имя читателя
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия читателя
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Отчество читателя
		/// </summary>
		public string Patronymic { get; set; }

		/// <summary>
		/// Адрес проживания
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// Название книги
		/// </summary>
		public string BookName { get; set; }

		/// <summary>
		/// Дата возврата
		/// </summary>
		public DateTime ReturnDate { get; set; }

		/// <summary>
		/// Сгенерировать строковое представление объекта.
		/// </summary>
		/// <returns>Строковое представление объекта.</returns>
		public override string ToString()
		{
			return $"Имя \"{FirstName}\" Фамилия \"{LastName}\" " +
					$"Отчество \"{Patronymic}\" " +
					$"Отчество \"{Patronymic}\" Адрес \"{Address}\" " +
					$"Книга \"{BookName}\" Дата возврата \"{ReturnDate.ToString("dd'.'MM'.'yyyy")}\"";
		}
	}
}
