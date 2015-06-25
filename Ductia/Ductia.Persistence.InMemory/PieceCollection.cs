using System.Collections.Generic;
using System.Linq;
using Ductia.Domain;

namespace Ductia.Persistence.InMemory
{
	internal class PieceCollection : List<Piece>
	{
		public Piece this[string index]
		{
			get { return this.SingleOrDefault(piece => piece.Title == index); }
		}
	}
}