using System.Collections.Generic;

namespace Ductia.Domain
{
	public class Piece : EntityBase
	{
		public string Title { get; set; }
		public string Composer { get; set; }
		public virtual IEnumerable<Book> Books { get; set; }
	}
}