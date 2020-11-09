using Bookstore.Model;

namespace DA.WinForms.Framework.Contracts.UI
{
	/// <ChangeLog>
	/// <Create Datum="08.11.2020" Entwickler="DA" />
	/// </ChangeLog>
	/// <summary>
	/// the views interface for displaying a books details
	/// </summary>
	public interface IBookDetail
	{
		/// <ChangeLog>
		/// <Create Datum="08.11.2020" Entwickler="DA" />
		/// </ChangeLog>
		/// <summary>
		/// Shows a <see cref="Book"/>s details
		/// </summary>
		/// <param name="book"></param>
		void SelectBook(Book book);
	}
}