using System.Linq;
using System.Net.Http;
using Ductia.Domain;
using Ductia.Persistence;
using Ductia.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace searchController
{
	[TestFixture]
    public class SearchControllerTests
	{
		private SearchController _controller;
		private Mock<IBookRepository> _bookRepositoryMock;
		private Mock<IPieceRepository> _pieceRepositoryMock;

		[SetUp]
		public void Setup()
		{
			_bookRepositoryMock = new Mock<IBookRepository>();
			_pieceRepositoryMock = new Mock<IPieceRepository>();
			_controller = new SearchController(_bookRepositoryMock.Object, _pieceRepositoryMock.Object);
		}

		[Test]
		public void When_SearchingForAPieceInABook_Should_UseRepository()
		{
			var title = "Some title";

			//act
			_controller.SearchBooks(title);

			//assert
			_bookRepositoryMock.Verify(rep => rep.SearchInPieces(title), Times.Once);
		}

		[Test]
		public void When_SearchingForAPieceInABook_And_CriteriaIsNull_Should_NotUseRepository()
		{
			string search = null;

			//act
			_controller.SearchBooks(search);

			//assert
			_bookRepositoryMock.Verify(rep => rep.SearchInPieces(search), Times.Never);
		}

		[Test]
		public void When_SearchingForAPieceInABook_And_CriteriaIsEmptyString_Should_Return_EmptyResult()
		{
			string search = string.Empty;

			//act
			_controller.SearchBooks(search);

			//assert
			_bookRepositoryMock.Verify(rep => rep.SearchInPieces(search), Times.Never);
		}

		[Test]
		public void When_SearchingForAPieceInABook_And_CriteriaIsWhiteSpace_Should_Return_EmptyResult()
		{
			string search = " ";

			//act
			_controller.SearchBooks(search);

			//assert
			_bookRepositoryMock.Verify(rep => rep.SearchInPieces(search), Times.Never);
		}

		[Test]
		public void When_SearchingForPieces_GivenInstrumentAndGrade_Should_UseTheRepository()
		{
			var instrument = Instrument.Flute;
			byte grade = 1;

			// Act
			_controller.SearchPieces(new GradeRequest{Instrument = instrument, SelectedGrades = new []{ grade}});

			// Assert
			_pieceRepositoryMock.Verify(rep => rep.SearchPieces(instrument, grade), Times.Once);
		}

		[Test]
		public void When_SearchingForPieces_GivenInstrumentOnly_Should_UseTheRepository()
		{
			var instrument = Instrument.Flute;

			// Act
			_controller.SearchPieces(new GradeRequest{Instrument = instrument});

			// Assert
			_pieceRepositoryMock.Verify(rep => rep.SearchPieces(instrument), Times.Once);
		}


    }
}
