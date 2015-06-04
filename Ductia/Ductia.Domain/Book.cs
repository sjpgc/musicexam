using System.Collections.Generic;

namespace Ductia.Domain
{
	public class Book : EntityBase
	{
		public string Title { get; set; }
		public string Isbn { get; set; }
		public string Publisher { get; set; }
		public virtual IEnumerable<Piece> Pieces { get; set; } 
	}
}