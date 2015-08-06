using System.Collections.Generic;
using System.Linq;

namespace Ductia.Domain
{
	public class Piece : EntityBase
	{
		public Piece()
		{
			Books = new List<Book>();
		}

		public string Title { get; set; }
		public string Composer { get; set; }
		public IEnumerable<Book> Books { get; set; }

		public void AddBook(Book book)
		{
			if (Books.All(b => b.Isbn != book.Isbn))
			{
				((IList<Book>)Books).Add(book);
			}
		}
	}
}