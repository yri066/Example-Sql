using ConsoleApp.Lib.Entities;
using ConsoleApp.Lib.Entities.ViewModels;
using ConsoleApp.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Lib.AdoNet
{
	/// <summary>
	/// Работа с бд через Ado.Net.
	/// </summary>
	public class AdoNetDataProvider : ISqlQuery
	{
		/// <summary>
		/// Строка подклюсения.
		/// </summary>
		private string _connectionString;

		/// <summary>
		/// Конструктор с параметром.
		/// </summary>
		/// <param name="connectionString">Строка подклюсения.</param>
		public AdoNetDataProvider(string connectionString)
		{
			if (string.IsNullOrEmpty(connectionString))
			{
				throw new ArgumentNullException(nameof(connectionString));
			}

			_connectionString = connectionString;
		}

		/// <summary>
		/// Сформировать список авторов и их книг.
		/// </summary>
		/// <returns>Список авторов и их книги.</returns>
		public IEnumerable<AuthorsBooksViewModel> GetAuthorBooks()
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				var qery =
					$@"SELECT TOP(1000)
						[Author].[FirstName],
						[Author].[LastName],
						[Author].[Patronymic],
						[Book].[Name],
						[Publisher].[Name]
					FROM [dbo].[Book]
						LEFT JOIN[dbo].[Author]
							ON[Author].[Id] = [Book].[AuthorId]
						LEFT JOIN[dbo].[Publisher]
							ON[Publisher].[Id] = [Book].[PublisherId]
					WHERE[Author].[Id] = [Book].[AuthorId]
					ORDER BY[Author].[FirstName]";

				var command = new SqlCommand(qery, connection);
				var result = new List<AuthorsBooksViewModel>();

				using (var reader = command.ExecuteReader())
				{
					if (!reader.HasRows)
					{
						return result;
					}

					while (reader.Read())
					{
						result.Add(new AuthorsBooksViewModel()
						{
							FirstName = reader.GetString(0),
							LastName = reader.GetString(1),
							Patronymic = reader.GetString(2),
							BookName = reader.GetString(3),
							PublisherName = reader.GetString(4)
						});
					}
				}

				return result;
			}
		}

		/// <summary>
		/// Сформировать список людей не вернувших книгу вовремя.
		/// </summary>
		/// <returns>Список людей с информацией о взятой книге.</returns>
		public IEnumerable<IssueReaderViewModel> GetReaderNotReturnedBook()
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				var qery =
					$@"SELECT TOP (1000) 
						[Reader].[FirstName],
						[Reader].[LastName],
						[Reader].[Patronymic],
						[Reader].[Address],
						[Book].[Name],
						[Issue].[ReturnDate]
					FROM [dbo].[Reader]
						INNER JOIN [dbo].[Issue]
							ON [Reader].[Id] = [Issue].[ReaderId]
						INNER JOIN [dbo].[Book]
							ON [Book].[Id] = [Issue].[BookId]
					WHERE GETDATE() > [Issue].[ReturnDate]
						AND [Issue].[Returned] = 0";

				var command = new SqlCommand(qery, connection);
				var result = new List<IssueReaderViewModel>();

				using (var reader = command.ExecuteReader())
				{
					if (!reader.HasRows)
					{
						return result;
					}

					while (reader.Read())
					{
						result.Add(new IssueReaderViewModel()
						{
							FirstName = reader.GetString(0),
							LastName = reader.GetString(1),
							Patronymic = reader.GetString(2),
							Address = reader.GetString(3),
							BookName = reader.GetString(4),
							ReturnDate = reader.GetDateTime(5)
						});
					}
				}

				return result;
			}
		}

		/// <summary>
		/// Найти автора по Id.
		/// </summary>
		/// <param name="id">Идентификатор</param>
		/// <returns>Автор.</returns>
		public Author GetAuthor(Guid id)
		{
			if (id == Guid.Empty)
			{
				throw new ArgumentNullException(nameof(id));
			}

			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				var qery =
					$@"SELECT TOP (1000) 
						[Author].[Id],
						[Author].[FirstName],
						[Author].[LastName],
						[Author].[Patronymic]
					FROM [dbo].[Author]
					WHERE [Author].[Id] = @Id";

				var command = new SqlCommand(qery, connection);
				command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
				command.Parameters["@Id"].Value = id;

				using (var reader = command.ExecuteReader())
				{
					if (!reader.HasRows)
					{
						return null;
					}

					reader.Read();

					return new Author()
					{
						Id = reader.GetGuid(0),
						FirstName = reader.GetString(1),
						LastName = reader.GetString(2),
						Patronymic = reader.GetString(3)
					};
				}
			}
		}

		/// <summary>
		/// Добавить автора.
		/// </summary>
		/// <param name="author">Автор.</param>
		public void AddAuthor(Author author)
		{
			if (author == null)
			{
				throw new ArgumentNullException(nameof(author));
			}

			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				var qery =
					$@"INSERT INTO [dbo].[Author] (
						[Id],
						[FirstName],
						[LastName],
						[Patronymic]
					)
					VALUES (
						NEWID(),
						@FirstName,
						@LastName,
						@Patronymic
					)";

				var command = new SqlCommand(qery, connection);
				command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = author.FirstName;
				command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = author.LastName;
				command.Parameters.Add("@Patronymic", SqlDbType.NVarChar).Value = author.Patronymic;

				command.ExecuteNonQuery();
			}
		}

		/// <summary>
		/// Сформировать список всех авторов.
		/// </summary>
		/// <returns>Список авторов.</returns>
		public IEnumerable<Author> GetAllAuthor()
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				var qery =
					$@"SELECT TOP (1000) 
						[Author].[Id],
						[Author].[FirstName],
						[Author].[LastName],
						[Author].[Patronymic]
					FROM [dbo].[Author]";

				var command = new SqlCommand(qery, connection);

				var result = new List<Author>();

				using (var reader = command.ExecuteReader())
				{
					if (!reader.HasRows)
					{
						return result;
					}

					while (reader.Read())
					{
						result.Add(new Author()
						{
							Id = reader.GetGuid(0),
							FirstName = reader.GetString(1),
							LastName = reader.GetString(2),
							Patronymic = reader.GetString(3),
						});
					}
				}

				return result;
			}
		}
	}
}
