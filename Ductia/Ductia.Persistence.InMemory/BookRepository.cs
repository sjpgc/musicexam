using System.Collections.Generic;
using System.Linq;
using Ductia.Domain;

namespace Ductia.Persistence.InMemory
{
	public class BookRepository : IBookRepository
	{
		public IEnumerable<Book> SearchInPieces(string pieceName)
		{
			var books = InMemoryStorage.Books.Where(b => b.Pieces.Any(p => p.Title.ToLower().Contains(pieceName.ToLower())));
			return books;
		}
	}
}