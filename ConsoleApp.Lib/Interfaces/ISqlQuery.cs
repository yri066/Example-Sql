using ConsoleApp.Lib.Entities;
using ConsoleApp.Lib.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Lib.Interfaces
{
	/// <summary>
	/// Методы для работы с бд.
	/// </summary>
	public interface ISqlQuery
	{
		/// <summary>
		/// Сформировать список авторов и их книг.
		/// </summary>
		/// <returns>Список авторов и их книги.</returns>
		IEnumerable<AuthorsBooksViewModel> GetAuthorBooks();

		/// <summary>
		/// Сформировать список людей не вернувших книгу вовремя.
		/// </summary>
		/// <returns>Список людей с информацией о взятой книге.</returns>
		IEnumerable<IssueReaderViewModel> GetReaderNotReturnedBook();

		/// <summary>
		/// Найти автора по Id.
		/// </summary>
		/// <param name="id">Идентификатор</param>
		/// <returns>Автор.</returns>
		Author GetAuthor(Guid id);

		/// <summary>
		/// Добавить автора.
		/// </summary>
		/// <param name="author">Автор.</param>
		void AddAuthor(Author author);

		/// <summary>
		/// Сформировать список всех авторов.
		/// </summary>
		/// <returns>Список авторов.</returns>
		IEnumerable<Author> GetAllAuthor();
	}
}
