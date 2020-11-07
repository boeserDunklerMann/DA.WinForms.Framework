using Bookstore.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DA.Dba.MongoDb
{
	public class BookService
	{
		private readonly IMongoCollection<Book> _books;
		private static readonly Lazy<BookService> lazy = new Lazy<BookService>(() => new BookService());
		public static BookService Instance => lazy.Value;

		private BookService()
		{
			// TODO: Get this from settings or elsewhere
			var client = new MongoClient("mongodb://192.168.1.4");
			var database = client.GetDatabase("BookstoreDb");
			_books = database.GetCollection<Book>("Books");
		}
		public List<Book> Get() => _books.Find(book => true).ToList();

		public Book Get(string id) => _books.Find<Book>(book => book.Id == id).FirstOrDefault();

		public Book Create(Book book)
		{
			_books.InsertOne(book);
			return book;
		}

		public void Update(string id, Book bookin) => _books.ReplaceOne(book => book.Id == id, bookin);

		public void Remove(Book bookin) => _books.DeleteOne(book => book.Id == bookin.Id);

		public void Remove(string id) => _books.DeleteOne(book => book.Id == id);
	}
}
