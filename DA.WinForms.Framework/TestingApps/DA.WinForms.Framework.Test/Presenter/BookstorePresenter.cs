using Bookstore.Model;
using DA.WinForms.Framework.Test.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DA.WinForms.Framework.Test.Presenter
{
	/// <ChangeLog>
	/// <Create Datum="08.11.2020" Entwickler="DA" />
	/// </ChangeLog>
	/// <summary>
	/// Presenter for Book(store)list
	/// </summary>
	public sealed class BookstorePresenter
	{
		//private readonly BookService service;
		private readonly Contracts.IDatabase _service;
		private readonly IBookStore _bookStoreView;
		private IEnumerable<Book> _allBooks;
		private Book _selectedBook;

		/// <ChangeLog>
		/// <Create Datum="08.11.2020" Entwickler="DA" />
		/// </ChangeLog>
		/// <summary>
		/// Creates the presenter
		/// </summary>
		/// <param name="bookStoreView">the view to the Bookstore (the list of all books)</param>
		public BookstorePresenter(IBookStore bookStoreView)
		{
			_bookStoreView = bookStoreView;
			_service = Commons.DependencyContainer.GetObject<Contracts.IDatabase>();
		//	service = BookService.Instance;
		}

		/// <ChangeLog>
		/// <Create Datum="08.11.2020" Entwickler="DA" />
		/// </ChangeLog>
		/// <summary>
		/// Loads and displays the books
		/// </summary>
		public void LoadBooks()
		{
			// TODO: async/await
			//Action action = () =>
			//  {
				  _allBooks = _service.Get();
				  _bookStoreView.DisplayBooks(_allBooks);
			//  };
			//Task task = new Task(action);
			//task.Start();
		}
		/// <ChangeLog>
		/// <Create Datum="08.11.2020" Entwickler="DA" />
		/// </ChangeLog>
		/// <summary>Selects a book</summary>
		public void SelectBook(Book book, IBookDetail detailView)
		{
			if (book != null)
				detailView.SelectBook(book);
			_selectedBook = book;
		}

		/// <ChangeLog>
		/// <Create Datum="08.11.2020" Entwickler="DA" />
		/// </ChangeLog>
		/// <summary>
		/// Saves the selected book
		/// </summary>
		public void Save()
		{
			// DONE: async
			new Task(() => _service.Update(_selectedBook.Id, _selectedBook)).Start();
			// TODO: do some error checking
			//service.Update(_selectedBook.Id, _selectedBook);
			// TODO: update the Bookstores list
		}
	}
}