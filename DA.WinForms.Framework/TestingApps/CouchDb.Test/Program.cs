using System;

namespace CouchDb.Test
{
	class Program
	{
		static void Main(string[] args)
		{
			var db = DA.WinForms.Framework.Commons.DependencyContainer.GetObject
				<DA.WinForms.Framework.Contracts.IDatabase>();
			Bookstore.Model.Book book = db.Get()[0];
			db.Update(null, book);
		}
	}
}
