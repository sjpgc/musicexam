﻿using System;
using System.Collections.Generic;
using System.Linq;
using Ductia.Domain;

namespace Ductia.Persistence.InMemory
{
	public class PieceRepository : IPieceRepository
	{
		public IEnumerable<GradePiece> SearchPieces(Instrument instrument, Byte grade)
		{
			var gradesForInstrument = InMemoryStorage.Grades.Where(p => p.Instrument == instrument && p.Level == grade).SelectMany(g => g.Pieces);

			return gradesForInstrument;
		}

		public IEnumerable<GradePiece> SearchPieces(Instrument instrument)
		{
			var gradesForInstrument = InMemoryStorage.Grades.Where(p => p.Instrument == instrument).SelectMany(g => g.Pieces);
			
			return gradesForInstrument;
		}
	}
}