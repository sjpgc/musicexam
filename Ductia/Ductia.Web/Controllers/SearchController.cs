using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ductia.Domain;
using Ductia.Persistence;
using Microsoft.Practices.Unity;

namespace Ductia.Web.Controllers
{
    public class SearchController : ApiController
    {
	    private readonly IBookRepository _bookRepository;
		
	    public SearchController(IBookRepository repository)
	    {
		    _bookRepository = repository;
	    }

		[HttpGet]
		[Route("search/books/{pieceName}")]
	    public IEnumerable<Book> SearchBooks(string pieceName)
		{
			return _bookRepository.SearchInPieces(pieceName);
		} 

    }
}
