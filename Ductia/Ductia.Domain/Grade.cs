using System;
using System.Collections.Generic;

namespace Ductia.Domain
{
	public class Grade : EntityBase
	{
		public Byte Level { get; set; }
		public Instrument Instrument { get; set; }
		public virtual IEnumerable<GradePiece> Pieces { get; set; }
	}
}
