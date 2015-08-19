using System.Collections.Generic;
using System.Linq;
using Ductia.Domain;
using NUnit.Framework;

namespace Ductia.Persistence.Tests
{
	[TestFixture]
    public abstract class PieceRepositoryTests
	{
		protected abstract IPieceRepository PieceRepository { get; }
		
		[TestFixtureSetUp]
		protected abstract void Setup();

		[TestFixtureTearDown]
		protected abstract void TearDown();


		[Test]
		public void When_SearchingPieces_Given_AnInstrument_Should_ReturnExpectedResults()
		{
			// Act
			var results = PieceRepository.SearchPieces(Instrument.Guitar);

			// Assert
			var grades = results as List<Grade> ?? results.ToList();
			Assert.AreEqual(2, grades.Count());
			Assert.AreEqual("title1", grades[0].Pieces.First().Piece.Title);
			Assert.AreEqual("title2", grades[1].Pieces.First().Piece.Title);
		}

		[Test]
		public void When_SearchingPieces_Given_AnInstrumentAndAGrade_Should_ReturnExpectedResults()
		{
			var results = PieceRepository.SearchPieces(Instrument.Guitar, 1);
			
			var gradePieces = results as List<Grade> ?? results.ToList();
			Assert.AreEqual(1, gradePieces.Count());
			Assert.AreEqual("title1", gradePieces[0].Pieces.First().Piece.Title);
		}

		[Test]
		public void When_SearchingPieces_Given_AnInstrumentAndANonExistingGrade_Should_ReturnNoResults()
		{
			var results = PieceRepository.SearchPieces(Instrument.Guitar, 255);
			
			Assert.AreEqual(0, results.Count());
		}
	}
}