using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Ductia.Domain;
using Ductia.Persistence;

namespace Ductia.Web.Controllers
{
    public class SearchController : ApiController
    {
	    private readonly IBookRepository _bookRepository;
	    private readonly IPieceRepository _pieceRepository;

	    public SearchController(IBookRepository bookRepository, IPieceRepository pieceRepository)
	    {
		    _bookRepository = bookRepository;
		    _pieceRepository = pieceRepository;
	    }

	    [HttpGet]
		[Route("search/books/{pieceName}")]
	    public IEnumerable<Book> SearchBooks(string pieceName)
		{
			if (pieceName == null) return new List<Book>();
			if (string.IsNullOrWhiteSpace(pieceName)) return new List<Book>();
			
			return _bookRepository.SearchInPieces(pieceName);
		}

	    [HttpGet]
	    [Route("search/pieces/{instrument}/{grade}")]
		public IEnumerable<SearchPiecesDTO> SearchPieces(Instrument instrument, Byte grade)
	    {
		    var results = 
				from result in _pieceRepository.SearchPieces(instrument, grade)
				//let rGrade = result.Level
				from piece in result.Pieces
				select new SearchPiecesDTO
			    {
					List = piece.List.ToString(),
					Title = piece.Piece.Title,
					Grade = grade
			    };
			return results;
	    }

		[HttpGet]
		[Route("search/pieces/{instrument}")]
		public IEnumerable<SearchPiecesDTO> SearchPieces(Instrument instrument)
		{
			var results =
				from result in _pieceRepository.SearchPieces(instrument)
				let rGrade = result.Level
				from piece in result.Pieces
				select new SearchPiecesDTO
				{
					List = piece.List.ToString(),
					Title = piece.Piece.Title,
					Grade = rGrade
				};
			return results;
		}

    }
}

namespace Ductia.Web.Code
{
}