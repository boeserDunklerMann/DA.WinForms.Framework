using Bookstore.Model;
using System.Collections.Generic;

namespace DA.WinForms.Framework.Contracts
{
	/// <ChangeLog>
	/// <Create Datum="09.11.2020" Entwickler="DA" />
	/// </ChangeLog>
	/// <summary>
	/// Interface for database accessors
	/// </summary>
	public interface IDatabase
	{
		Book Create(Book book);
		List<Book> Get();
		Book Get(string id);
		void Remove(Book bookin);
		void Remove(string id);
		void Update(string id, Book bookin);
	}
}
