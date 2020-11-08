using System.Collections.Generic;

namespace DA.WinForms.Framework.Test.Interfaces
{
	/// <ChangeLog>
	/// <Create Datum="08.11.2020" Entwickler="DA" />
	/// </ChangeLog>
	/// <summary>
	/// the views interface for displaying a list of all books
	/// </summary>
	public interface IBookStore
	{
		/// <ChangeLog>
		/// <Create Datum="08.11.2020" Entwickler="DA" />
		/// </ChangeLog>
		/// <summary>
		/// Displays a list of <see cref="Bookstore.Model.Book"/>s
		/// </summary>
		void DisplayBooks(IEnumerable<Bookstore.Model.Book> books);
	}
}