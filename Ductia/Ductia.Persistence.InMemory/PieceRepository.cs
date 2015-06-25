using System;
using System.Collections.Generic;
using Ductia.Domain;

namespace Ductia.Persistence.InMemory
{
	public class PieceRepository : IPieceRepository
	{
		public IEnumerable<GradePiece> SearchPieces(Instrument instrument, Byte grade)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<GradePiece> SearchPieces(Instrument instrument)
		{
			throw new NotImplementedException();
		}
	}
}