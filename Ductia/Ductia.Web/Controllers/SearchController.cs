using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ductia.Domain;

namespace Ductia.Web.Controllers
{
    public class SearchController : ApiController
    {
	    private readonly IBookRepository _bookRepository;
		
	    public SearchController()
	    {
		    _bookRepository = new BookRepository();
	    }

        // GET api/search
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/search/5
        public string Get(int id)
        {
            return "value";
        }

		[HttpGet]
		[Route("search/books/{pieceName}")]
	    public IEnumerable<Book> SearchBooks(string pieceName)
		{
			return _bookRepository.SearchInPieces(pieceName);
		} 


        // POST api/search
        public void Post([FromBody]string value)
        {
        }

        // PUT api/search/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/search/5
        public void Delete(int id)
        {
        }
    }
}
