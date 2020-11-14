using Bookstore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using RedBranch.Hammock;

namespace DA.Dba.CouchDb
{
	public class BookService : DA.WinForms.Framework.Contracts.IDatabase
	{
		private readonly Connection _connection;
		private readonly Session _session;

		private List<Book> _books;
		private BookService()
		{
			//_connection = new RedBranch.Hammock.Connection(new Uri("http://192.168.1.3:5984"));
			//if (!_connection.ListDatabases().Contains("bookstoredb"))
			//	throw new ApplicationException("Database not found");
			//_session = _connection.CreateSession("bookstoredb");
			//_books = new List<Book>();
			LoadAllBooks();
		}

		private async void LoadAllBooks()
		{
			/*
			var entities = _session.ListEntities();
			entities.ToList().ForEach(e =>
			{
				_books.Add(e.ToObject<Book>());
			});
			*/
			using (var couchclient = new MyCouch.MyCouchClient("http://192.168.1.3:5984", "bookstoredb"))
			{
				MyCouch.Responses.DocumentResponse docResp = couchclient.Documents.GetAsync("f695a7c08c03b0a54d874a6fe000031e").Result;
				string json = docResp.Content;
				var objs = Newtonsoft.Json.JsonConvert.DeserializeObject<Book>(json);
			}
		}

		#region CRUD-Operations
		public Book Create(Book book)
		{
			_session.Save<Book>(book);
			return book;
		}

		public List<Book> Get()
		{
			return _books;
		}

		public Book Get(string id)
		{
			return _session.Load<Book>(id);
		}

		public void Remove(Book bookin)
		{
			_session.Delete<Book>(bookin);
		}

		public void Remove(string id)
		{
			Remove(Get(id));
		}

		public void Update(string id, Book bookin)
		{
			_session.Save<Book>(bookin);
		}
		#endregion
	}
}
