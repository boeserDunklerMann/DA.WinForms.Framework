using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA.WinForms.Framework;
using Bookstore.Model;
using DA.WinForms.Framework.Model;

namespace DA.WinForms.Framework.Test
{
	public partial class BookForm : Form, IBindableControl
	{
		DataClassBase IBindableControl.DataSource { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		// TODO: Get this from Presenter or elsewhere
		/*
		Book _myBook = new Book() { Author = "Stephen King",
									BookName = "Pet Cemetary",
									Price = 12.99M,
									IsHardcover=false,
									Category="Love story" };
		*/
		Book _myBook;
		public BookForm()
		{
			InitializeComponent();
			_myBook = DA.Dba.MongoDb.BookService.Instance.Get()[0];
			Bind();
		}

		private void btnHitme_Click(object sender, EventArgs e)
		{
			// the changes are now in our dataobject. see!
			if (_myBook.Validate())
			{
				string hardcover = _myBook.IsHardcover ? "yes" : "no";
				MessageBox.Show($"Author: {_myBook.Author}\r\nTitle: {_myBook.BookName}\r\nPrice is: {_myBook.Price}\r\nIS a hardcover: {hardcover}\r\n" +
					$"Category: {_myBook.Category}");
				DA.Dba.MongoDb.BookService.Instance.Update(_myBook.Id, _myBook);
			}
		}

		public void Bind()
		{
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
}
