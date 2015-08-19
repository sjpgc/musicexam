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
		public IEnumerable<object> SearchBooks(string pieceName)
		{
			if (pieceName == null) return new List<Book>();
			if (string.IsNullOrWhiteSpace(pieceName)) return new List<Book>();

			var books = GetBooksDto(_bookRepository.SearchInPieces(pieceName));

			return books;
		}
		
		[HttpPost]
		[Route("search/pieces")]
		public IEnumerable<SearchPiecesDTO> SearchPieces([FromBody] GradeRequest request)
		{
			var results =
				from result in _pieceRepository.SearchPieces(request.Instrument, request.SelectedGrades)
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
		
		
		[HttpPost]
		[Route("search/books")]
		public IEnumerable<object> SearchBooks([FromBody] GradeRequest bookRequest)
		{
			var results = _pieceRepository.SearchBooks(bookRequest.Board, bookRequest.Instrument, bookRequest.SelectedGrades);
			return GetBooksDto(results);
		}
		

	    private static IEnumerable<object> GetBooksDto(IEnumerable<Book> books)
	    {
		    return books.Select(bk => new {title = bk.Title, isbn = bk.Isbn, publisher = bk.Publisher});
	    } 


    }
}
