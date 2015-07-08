using System.Collections.Generic;
using Ductia.Domain;

namespace Ductia.Persistence
{
	public interface IPieceRepository
	{
		IEnumerable<GradePiece> SearchPieces(Instrument instrument, byte grade);
		IEnumerable<GradePiece> SearchPieces(Instrument instrument);
	}
}