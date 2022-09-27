using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Lib.Entities.ViewModels
{
	/// <summary>
	/// Информация о авторе и его книгах
	/// </summary>
	public class AuthorsBooksViewModel
	{
		/// <summary>
		/// Имя автора
		/// </summary>
		public string FirstName;

		/// <summary>
		/// Фамилия автора
		/// </summary>
		public string LastName;

		/// <summary>
		/// Отчество автора
		/// </summary>
		public string Patronymic;

		/// <summary>
		/// Название книги
		/// </summary>
		public string BookName;

		/// <summary>
		/// Название издательства
		/// </summary>
		public string PublisherName;

		/// <summary>
		/// Сгенерировать строковое представление объекта.
		/// </summary>
		/// <returns>Строковое представление объекта.</returns>
		public override string ToString()
		{
			return $"Имя \"{FirstName}\" Фамилия \"{LastName}\" " +
					$"Отчество \"{Patronymic}\" Книга \"{BookName}\" " +
					$"Издатель \"{PublisherName}\"";
		}
	}
}
