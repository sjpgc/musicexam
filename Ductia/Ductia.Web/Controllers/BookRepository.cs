using System;
using System.Collections.Generic;
using System.Linq;
using Ductia.Domain;

namespace Ductia.Web.Controllers
{
	public class BookRepository : IBookRepository
	{
		public List<Book> bookData
		{
			get
			{
				return new List<Book>
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
		}

		public IEnumerable<Book> SearchInPieces(string pieceName)
		{
			var books = bookData.Where(b => b.Pieces.Any(p => p.Title.ToLower().Contains(pieceName.ToLower())));
			return books;
		}
	}
}