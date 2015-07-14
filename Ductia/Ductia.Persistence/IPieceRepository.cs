using System.Collections.Generic;
using Ductia.Domain;

namespace Ductia.Persistence
{
	public interface IPieceRepository
	{
		IEnumerable<Grade> SearchPieces(Instrument instrument, byte grade);
		IEnumerable<Grade> SearchPieces(Instrument instrument);
	}
}