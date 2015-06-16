using System.Collections.Generic;
using Ductia.Domain;

namespace Ductia.Persistence
{
	public interface IBookRepository
	{
		IEnumerable<Book> SearchInPieces(string pieceName);
	}
}