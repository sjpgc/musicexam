using System;
using System.Collections.Generic;
using Ductia.Domain;

namespace Ductia.Persistence.InMemory
{
	internal static class InMemoryStorage
	{

		private static List<Book> _books;  

		static InMemoryStorage()
		{
			_books = new List<Book>
			    {
				    new Book {Id = Guid.NewGuid(), Title = "Some title", Publisher = "Acme ltd.", Isbn = "47859375", Pieces = new List<Piece>
				    {
					    new Piece {Title = "Il Barbiere di Siviglia"},
					    new Piece {Title = "Water Music"},
					    new Piece {Title = "The Music for the Royal Fireworks"},
				    }},
				    new Book {Id = Guid.NewGuid(), Title = "Some other title", Publisher = "Pub ltd", Isbn = "485347895", Pieces = new List<Piece>
				    {
					    new Piece{ Title = "Mikado"},
						new Piece{Title = "Nimrod"},
						new Piece{Title = "The Planets"},
						new Piece {Title = "Water Music"},
				    }},
			    };
		}

		public static IEnumerable<Book> Books
		{
			get { return _books; }
		}
	}
}
