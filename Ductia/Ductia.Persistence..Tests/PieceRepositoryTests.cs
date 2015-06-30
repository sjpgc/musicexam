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
		protected void When_SearchingPieces_Given_AnInstrument_Should_ReturnExpectedResults()
		{
			// Act

			var results = PieceRepository.SearchPieces(Instrument.Guitar);

			// Assert

			Assert.AreEqual(results.Count(), 1);

		}

		//[Test]
		//protected void When_SearchingPieces_Given_AnInstrumentAndAGrade_Should_ReturnExpectedResults()
		//{

		//}

		//[Test]
		//protected void When_SearchingPieces_Given_AnInstrumentAndANonExistingGrade_Should_ReturnNoResults()
		//{

		//}
	}
}