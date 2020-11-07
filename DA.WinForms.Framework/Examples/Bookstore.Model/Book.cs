using DA.WinForms.Framework.Model;
using DA.WinForms.Framework.Attributes;
using System;

namespace Bookstore.Model
{
	public class Book : DataClassBase
	{
		public Guid Id { get; set; }
		public string BookName { get; set; }
		public string Author { get; set; }
		public decimal Price { get; set; }
		public bool IsHardcover { get; set; }

		[ValidValues("Science", "Technology", "Novel")]
		public string Category { get; set; }
	}
}
