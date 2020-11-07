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

namespace DA.WinForms.Framework.Test
{
	public partial class BookForm : Form
	{
		// TODO: Get this from Presenter or elsewhere
		Book _myBook = new Book() { Author = "Stephen King", BookName = "Pet Cemetary", Price = 12.99M, Id = Guid.Empty };
		public BookForm()
		{
			InitializeComponent();

			// Bind the TextBoxes to our DataObject
			BindingCreator<Book> bc = new BindingCreator<Book>(_myBook);
			txtAuthor.DataBindings.Add(bc.CreateBinding(nameof(Book.Author)));
			txtTitle.DataBindings.Add(bc.CreateBinding(nameof(Book.BookName)));
			txtPrice.DataBindings.Add(bc.CreateBinding(nameof(Book.Price), true));
		}

		private void btnHitme_Click(object sender, EventArgs e)
		{
			// the changes are now in our dataobject. see!
			MessageBox.Show($"Author: {_myBook.Author}\r\nTitle: {_myBook.BookName}\r\nPrice is: {_myBook.Price}");
		}
	}
}
