using System;
using System.Collections.Generic;
using System.Linq;
using Ductia.Domain;

namespace Ductia.Persistence.InMemory
{
	public class PieceRepository : IPieceRepository
	{
		public IEnumerable<Grade> SearchPieces(Instrument instrument, Byte grade)
		{
			//var gradesForInstrument = InMemoryStorage.Grades.Where(p => p.Instrument == instrument && p.Level == grade).SelectMany(g => g.Pieces);
			var gradesForInstrument = InMemoryStorage.Grades.Where(p => p.Instrument == instrument && p.Level == grade);

			return gradesForInstrument;
		}

		public IEnumerable<Grade> SearchPieces(Instrument instrument)
		{
			//var gradesForInstrument = InMemoryStorage.Grades.Where(p => p.Instrument == instrument).SelectMany(g => g.Pieces);
			var gradesForInstrument = InMemoryStorage.Grades.Where(p => p.Instrument == instrument);
			
			return gradesForInstrument;
		}
	}
}