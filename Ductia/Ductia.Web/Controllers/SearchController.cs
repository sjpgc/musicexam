using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ductia.Domain;

namespace Ductia.Web.Controllers
{
    public class SearchController : ApiController
    {
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
			return new List<Book>
			{
				new Book {Id = Guid.NewGuid(), Title ="Some title", Publisher = "Acme ltd.", Isbn = "47859375"},
				new Book {Id = Guid.NewGuid(), Title = "Some other title", Publisher = "Pub ltd", Isbn = "485347895"},
			};
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
