using System;

namespace Bookstore.Model
{
	public class Book
	{
		public Guid Id { get; set; }
		public string BookName { get; set; }
		public string Author { get; set; }
		public decimal Price { get; set; }
	}
}
