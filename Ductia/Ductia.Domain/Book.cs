using System.Collections.Generic;
using System.Linq;

namespace Ductia.Domain
{
	public class Book : EntityBase
	{
		public Book()
		{
			Pieces = new List<Piece>();
		}

		public string Title { get; set; }
		public string Isbn { get; set; }
		public string Publisher { get; set; }
		public IEnumerable<Piece> Pieces { get; set; }


		public Book AddPiece(Piece piece)
		{
			piece.AddBook(this);
			((IList<Piece>)Pieces).Add(piece);

			return this;
		}
	}
}