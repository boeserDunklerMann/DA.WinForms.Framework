using Bookstore.Model;
using DA.WinForms.Framework.Contracts.UI;
using DA.WinForms.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DA.WinForms.Framework.Test
{
	/// <ChangeLog>
	/// <Create Datum="07.11.2020" Entwickler="DA" />
	/// </ChangeLog>
	/// <summary>
	/// Interaction logic for the view
	/// </summary>
	public partial class BookForm : Form, IBindableControl, IBookStore, IBookDetail
	{
		DataClassBase IBindableControl.DataSource { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		/// <summary>
		/// Book object for displaying in the detailed section
		/// </summary>
		Book _myBook;

		private readonly Presenter.BookstorePresenter bookstorePresenter;
		public BookForm()
		{
			bookstorePresenter = new Presenter.BookstorePresenter(this);
			InitializeComponent();
			bookstorePresenter.LoadBooks();
			Bind();
		}

		private void btnHitme_Click(object sender, EventArgs e)
		{
			// the changes are now in our dataobject. see!
			// TODO: Validation into Presenter
			if (_myBook.Validate())
			{
				string hardcover = _myBook.IsHardcover ? "yes" : "no";
				MessageBox.Show($"Author: {_myBook.Author}\r\nTitle: {_myBook.BookName}\r\nPrice is: {_myBook.Price}\r\nIS a hardcover: {hardcover}\r\n" +
					$"Category: {_myBook.Category}");
				bookstorePresenter.Save();
			}
		}
		/// <ChangeLog>
		/// <Create Datum="08.11.2020" Entwickler="DA" />
		/// </ChangeLog>
		/// <summary>
		/// Binds the detailview-conrols
		/// </summary>
		public void Bind()
		{
			if (_myBook != null)
			{
				// clear all bindings
				BindingCreator<Book>.ClearAllBindings(this);
				// Bind the TextBoxes to our DataObject
				BindingCreator<Book> bc = new BindingCreator<Book>(_myBook);
				txtAuthor.DataBindings.Add(bc.CreateBinding(nameof(Book.Author)));
				txtTitle.DataBindings.Add(bc.CreateBinding(nameof(Book.BookName)));
				txtPrice.DataBindings.Add(bc.CreateBinding(nameof(Book.Price), true));
				// bind a bool
				bc.CreateBinding(nameof(Book.IsHardcover), cbHardcover);
				// bind a combobox with validvalues
				bc.CreateBinding(nameof(Book.Category), cbCategory);
				// now fill them
				ComboboxFiller.Fill(this);
			}
		}

		/// <ChangeLog>
		/// <Create Datum="08.11.2020" Entwickler="DA" />
		/// </ChangeLog>
		/// <summary>
		/// Displays a list of books
		/// </summary>
		/// <param name="books">the books</param>
		public void DisplayBooks(IEnumerable<Book> books)
		{
			dgvBooks.DataSource = books;
		}

		/// <ChangeLog>
		/// <Create Datum="08.11.2020" Entwickler="DA" />
		/// </ChangeLog>
		/// <summary>
		/// Opens the selected book in the detailview
		/// </summary>
		private void dgvBooks_Click(object sender, EventArgs e)
		{
			Book selectedBook = (Book)dgvBooks.CurrentRow?.DataBoundItem;
			bookstorePresenter.SelectBook(selectedBook, this);
		}

		/// <ChangeLog>
		/// <Create Datum="08.11.2020" Entwickler="DA" />
		/// </ChangeLog>
		/// <summary>
		/// Selects a book
		/// </summary>
		public void SelectBook(Book book)
		{
			_myBook = book;
			Bind();
		}
	}
}