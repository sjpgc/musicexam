using System.Collections.Generic;

namespace Ductia.Domain
{
	public class Book : EntityBase
	{
		public string Isbn { get; set; }
		public string Publisher { get; set; }
		public IEnumerable<Piece> Pieces { get; set; } 
	}
}