using System;
using System.Collections.Generic;
using System.Linq;
using Ductia.Domain;
using Ductia.Persistence.Tests;
using NUnit.Framework;

namespace Ductia.Persistence.InMemory.Tests
{
	public class InMemoryPieceRepositoryTest : PieceRepositoryTests
	{
		private List<Grade> listOfGrades;

		protected override IPieceRepository PieceRepository
		{
			get { return new PieceRepository(); }
		}

		protected override void Setup()
		{
			var _pieces = new PieceCollection()
			{
				new Piece {Title = "title1"},
				new Piece {Title = "title2"},
				new Piece {Title = "Ttitle3"},
			};

			var gradedPieces = new List<GradePiece>
			{
				new GradePiece()
				{
					List = PieceList.A,
					Piece = _pieces["title1"]
					
				},
				new GradePiece()
				{
					List = PieceList.A,
					Piece = _pieces["title2"]
				},
				new GradePiece()
				{
					List = PieceList.A,
					Piece = _pieces["title3"]
				}
			};

			listOfGrades = new List<Grade>
			{
				new Grade
				{
					Level = 1,
					Instrument = Instrument.Guitar,
					Pieces = new List<GradePiece>
					{
						gradedPieces[0]
						
					}
					
				},
				new Grade
				{
					Level = 2,
					Instrument = Instrument.Guitar,
					Pieces = new List<GradePiece>
					{
						gradedPieces[1]
					}
					
				},
				new Grade
				{
					Level = 2,
					Instrument = Instrument.AltoRecorder,
					Pieces = new List<GradePiece>
					{
						gradedPieces[2]
					}
				}
			};

			listOfGrades.ForEach(grd =>  InMemoryStorage.Grades.Add(grd));

		}

		protected override void TearDown()
		{
			InMemoryStorage.Grades.ToList().Remove(listOfGrades[0]);
			InMemoryStorage.Grades.ToList().Remove(listOfGrades[1]);
			InMemoryStorage.Grades.ToList().Remove(listOfGrades[2]);
		}

	}
}
