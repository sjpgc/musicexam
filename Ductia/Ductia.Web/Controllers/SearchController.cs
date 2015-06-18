using System;
using System.Collections.Generic;
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
	    public IEnumerable<GradePiece> SearchPieces(String intrument, String grade)
	    {
		    return new List<GradePiece>();
	    }

    }
}