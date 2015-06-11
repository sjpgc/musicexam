using System.Collections;
using System.Collections.Generic;
using Ductia.Domain;

namespace Ductia.Web.Controllers
{
	public interface IBookRepository
	{
		IEnumerable<Book> SearchInPieces(string pieceName);
	}
}