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

		public IEnumerable<Book> SearchBooks(Instrument instrument, IEnumerable<byte> grades)
		{
			var result =
				from g in grades.Distinct()
				from grade in InMemoryStorage.Grades.Where(gr => gr.Instrument == instrument && gr.Level == g)
				from piece in grade.Pieces
				select piece;
				
			var a = result.SelectMany(piece => piece.Piece.Books);

			return a;
		}


		public IEnumerable<Grade> SearchPieces(Instrument instrument, IEnumerable<byte> grades)
		{
			var gradesForInstrument =
				from g in grades.Distinct()
				from grade in InMemoryStorage.Grades
				.Where (p => p.Instrument == instrument && p.Level == g)
				select grade;
			return gradesForInstrument;
		}
	}
}